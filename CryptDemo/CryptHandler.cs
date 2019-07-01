using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace CryptDemo
{
    static class CryptHandler
    {
        // #### Maximum size to encryt with RSA

        // PKCS #1 V1.5 Padding (RSAEncryptionPadding.Pkcs1)
        // ((KeySize - 384) / 8) + 37
        // ((2048 - 384) / 8) + 37 = 245 Bytes

        // OAEP Padding (RSAEncryptionPadding.OaepSHAXXX)
        // ((KeySize - 384) / 8) + 7
        // ((2048 - 384) / 8) + 7 = 215 Bytes


        public static int DefaultKeySize { get; } = 2048;
        public static Encoding Encoding { get; } = Encoding.Unicode;

        public static CryptKey CreateKey()
        {
            return CryptHandler.CreateKey(CryptHandler.DefaultKeySize);
        }
        public static CryptKey CreateKey(int keySize)
        {
            using (var algorithm = CryptHandler.CreateAsymmetric(keySize))
            {
                return new CryptKey() { PrivateKey = algorithm.ToXmlString(true), PublicKey = algorithm.ToXmlString(false) };
            }
        }

        private static RSA CreateAsymmetric(int keySize)
        {
            return new RSACng(keySize);
        }
        private static RSA CreateAsymmetric(string xmlKey)
        {
            var algorithm = new RSACng();
            algorithm.FromXmlString(xmlKey);
            return algorithm;
        }

        private static SymmetricAlgorithm CreateSymmetric()
        {
            return SymmetricAlgorithm.Create();
        }

        private static HashAlgorithm CreateHash()
        {
            return new SHA256Cng();
        }

        private static EncryptedSymmetric EncryptSymmetric(string message)
        {
            EncryptedSymmetric encrypted;
            using (var symmetric = CryptHandler.CreateSymmetric())
            {
                symmetric.GenerateIV();
                symmetric.GenerateKey();

                using (var ms = new System.IO.MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, symmetric.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (var writer = new StreamWriter(cs, CryptHandler.Encoding))
                        {
                            writer.Write(message);
                        }
                    }

                    encrypted = new EncryptedSymmetric()
                    {
                        Name = symmetric.GetType().BaseType.Name,
                        IV = symmetric.IV,
                        Key = symmetric.Key,
                        Encrypted = ms.ToArray()
                    };
                }
                symmetric.Clear();
            }
            return encrypted;
        }

        private static string DecryptSymmetric(byte[] message, byte[] iv, byte[] key)
        {
            var plainText = "";

            using (var symmetric = CryptHandler.CreateSymmetric())
            {
                using (var ms = new System.IO.MemoryStream(message))
                {
                    using (var cs = new CryptoStream(ms, symmetric.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(cs, CryptHandler.Encoding))
                        {
                            plainText = reader.ReadToEnd();
                            reader.Close();
                        }
                    }
                }
                symmetric.Clear();
            }

            return plainText;
        }

        private static Hashed Hash(byte[] data)
        {
            using (var hash = CryptHandler.CreateHash())
            {
                return new Hashed()
                {
                    Name = hash.GetType().BaseType.Name,
                    Data = hash.ComputeHash(data)
                };
            }
        }

        private static RSASignaturePadding padding = RSASignaturePadding.Pss;

        public static EncryptedAsymmetric Encrypt(string xmlPrivateKey, string xmlPublicKey, string message)
        {
            EncryptedAsymmetric output = new EncryptedAsymmetric();

            var symmetric = EncryptSymmetric(message);
            output.SymmetricData = symmetric.Encrypted;
            output.SymmetricName = symmetric.Name;
            output.SymmetricIVLength = symmetric.IV.Length;
            output.SymmetricKeyLength = symmetric.Key.Length;

            var hashed = Hash(CryptHandler.Encoding.GetBytes(message));
            //output.HashData = hashed.Data;
            output.HashName = hashed.Name;
            output.HashLength = hashed.Data.Length;

            using (var cryptAlgorithm = CryptHandler.CreateAsymmetric(xmlPrivateKey))
            {
                // Sign with PrivateKey, so the receiver can make sure that the sender
                // is correct, because only sender PublicKey will be able to verify signature.

                List<byte> dataToSign = new List<byte>();
                dataToSign.AddRange(symmetric.IV);
                dataToSign.AddRange(symmetric.Key);
                dataToSign.AddRange(hashed.Data);

                //output.AsymmetricSignature = cryptAlgorithm.SignHash(output.HashData, new HashAlgorithmName(hashed.Name), padding);
                output.AsymmetricSignature = cryptAlgorithm.SignData(dataToSign.ToArray(), new HashAlgorithmName(hashed.Name), padding);
                //output.AsymmetricSignatureLength = output.AsymmetricSignature.Length;
            }

            using (var cryptAlgorithm = CryptHandler.CreateAsymmetric(xmlPublicKey))
            {
                // Encrypt with receiver PublicKey, so only receiver PrivateKey will
                // be able to decrypt it.

                List<byte> dataToEncrypt = new List<byte>();
                dataToEncrypt.AddRange(symmetric.IV);
                dataToEncrypt.AddRange(symmetric.Key);
                dataToEncrypt.AddRange(hashed.Data);
                //dataToEncrypt.AddRange(output.AsymmetricSignature);

                output.AsymmetricData = cryptAlgorithm.Encrypt(dataToEncrypt.ToArray(), RSAEncryptionPadding.OaepSHA256);
                output.AsymmetricName = cryptAlgorithm.GetType().BaseType.Name;
            }

            return output;
        }

        public static string Decrypt(string xmlPivateKey, string xmlPublicKey, EncryptedAsymmetric input)
        {
            EncryptedSymmetric symmetric = new EncryptedSymmetric()
            {
                Name = input.SymmetricName,
                IV = new byte[input.SymmetricIVLength],
                Key = new byte[input.SymmetricKeyLength]
            };
            Hashed hashed = new Hashed()
            {
                Name = input.HashName,
                Data = new byte[input.HashLength]
            };

            byte[] asymmetricDataDecrypted;
            using (var cryptAlgorithm = CryptHandler.CreateAsymmetric(xmlPivateKey))
            {
                asymmetricDataDecrypted = cryptAlgorithm.Decrypt(input.AsymmetricData, RSAEncryptionPadding.OaepSHA256);
            }

            int sourceStartPosition = 0;
            Array.Copy(asymmetricDataDecrypted, sourceStartPosition, symmetric.IV, 0, input.SymmetricIVLength);
            sourceStartPosition += input.SymmetricIVLength;
            Array.Copy(asymmetricDataDecrypted, sourceStartPosition, symmetric.Key, 0, input.SymmetricKeyLength);
            sourceStartPosition += input.SymmetricKeyLength;
            Array.Copy(asymmetricDataDecrypted, sourceStartPosition, hashed.Data, 0, input.HashLength);

            using (var cryptAlgorithm = CryptHandler.CreateAsymmetric(xmlPublicKey))
            {
                //byte[] dataToVerify = new byte[input.SymmetricIVLength + input.SymmetricKeyLength + input.HashLength];
                //Array.Copy(asymmetricDataDecrypted, 0, dataToVerify, 0, dataToVerify.Length);

                bool isDataVerified = cryptAlgorithm.VerifyData(asymmetricDataDecrypted, input.AsymmetricSignature, new HashAlgorithmName(input.HashName), padding);
                if (!isDataVerified)
                {
                    throw new Exception("Crypt data can't be verified.");
                }

                //bool isHashVerified = cryptAlgorithm.VerifyHash(hashed.Data, input.AsymmetricSignature, new HashAlgorithmName(input.HashName), padding);
                //if (!isHashVerified)
                //{
                //    throw new Exception("Crypt hash can't be verified.");
                //}
            }

            var symmetricDataDecrypted = DecryptSymmetric(input.SymmetricData, symmetric.IV, symmetric.Key);
            var hashedToCompare = Hash(CryptHandler.Encoding.GetBytes(symmetricDataDecrypted));
            var isHashVerified = hashedToCompare.Data.SequenceEqual(hashed.Data);
            if (!isHashVerified)
            {
                throw new Exception("Hash can't be verified.");
            }
            return symmetricDataDecrypted;
        }

        private class EncryptedSymmetric
        {
            public string Name { get; set; }
            public byte[] IV { get; set; }
            public byte[] Key { get; set; }
            public byte[] Encrypted { get; set; }
        }

        private class Hashed
        {
            public string Name { get; set; }
            public byte[] Data { get; set; }
        }
    }

    public class CryptKey
    {
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
    }
    public class EncryptedAsymmetric
    {
        public string SymmetricName { get; set; }
        public byte[] SymmetricData { get; set; }
        public int SymmetricIVLength { get; set; }
        public int SymmetricKeyLength { get; set; }

        public string AsymmetricName { get; set; }
        public byte[] AsymmetricData { get; set; }
        public byte[] AsymmetricSignature { get; set; }
        //public int AsymmetricSignatureLength { get; set; }

        public string HashName { get; set; }
        //public byte[] HashData { get; set; }
        public int HashLength { get; set; }
    }
}
