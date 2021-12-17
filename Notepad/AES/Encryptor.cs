using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace AES
{
    class Encryptor
    {
        private const string _SALT = "g46dzQ80";
        private const string _INITVECTOR = "OFRna74m*aze01xY";

        private static byte[] _saltBytes;
        private static byte[] _initVectorBytes;

        static Encryptor()
        {
            _saltBytes = Encoding.UTF8.GetBytes(_SALT);
            _initVectorBytes = Encoding.UTF8.GetBytes(_INITVECTOR);
        }

        public static string Encrypt(string plainText, string password, string salt = null, string initialVector = null)
        {
            return Convert.ToBase64String(EncryptToBytes(plainText, password, salt, initialVector));
        }

        public static byte[] EncryptToBytes(string plainText, string password, string salt = null, string initialVector = null)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return EncryptToBytes(plainTextBytes, password, salt, initialVector);
        }

        public static byte[] EncryptToBytes(byte[] plainTextBytes, string password, string salt = null, string initialVector = null)
        {
            int keySize = 256;

            byte[] initialVectorBytes = string.IsNullOrEmpty(initialVector) ? _initVectorBytes : Encoding.UTF8.GetBytes(initialVector);
            byte[] saltValueBytes = string.IsNullOrEmpty(salt) ? _saltBytes : Encoding.UTF8.GetBytes(salt);
            byte[] keyBytes = new Rfc2898DeriveBytes(password, saltValueBytes).GetBytes(keySize / 8);

            using (RijndaelManaged symmetricKey = new RijndaelManaged())
            {
                symmetricKey.Mode = CipherMode.CBC;

                using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initialVectorBytes))
                {
                    using (MemoryStream memStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                            cryptoStream.FlushFinalBlock();

                            return memStream.ToArray();
                        }
                    }
                }
            }
        }

    }
}
