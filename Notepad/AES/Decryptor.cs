using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace AES
{
    class Decryptor
    {

        private const string _SALT = "g46dzQ80";
        private const string _INITVECTOR = "OFRna74m*aze01xY";

        private static byte[] _saltBytes;
        private static byte[] _initVectorBytes;

        static Decryptor()
        {
            _saltBytes = Encoding.UTF8.GetBytes(_SALT);
            _initVectorBytes = Encoding.UTF8.GetBytes(_INITVECTOR);
        }

        public static string Decrypt(string cipherText, string password, string salt = null, string initialVector = null)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText.Replace(' ', '+'));
            return Decrypt(cipherTextBytes, password, salt, initialVector).TrimEnd('\0');
        }

        public static string Decrypt(byte[] cipherTextBytes, string password, string salt = null, string initialVector = null)
        {
            int keySize = 256;

            byte[] initialVectorBytes = string.IsNullOrEmpty(initialVector) ? _initVectorBytes : Encoding.UTF8.GetBytes(initialVector);
            byte[] saltValueBytes = string.IsNullOrEmpty(salt) ? _saltBytes : Encoding.UTF8.GetBytes(salt);
            byte[] keyBytes = new Rfc2898DeriveBytes(password, saltValueBytes).GetBytes(keySize / 8);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            using (RijndaelManaged symmetricKey = new RijndaelManaged())
            {
                symmetricKey.Mode = CipherMode.CBC;

                using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initialVectorBytes))
                {
                    using (MemoryStream memStream = new MemoryStream(cipherTextBytes))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read))
                        {
                            int byteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                            return Encoding.UTF8.GetString(plainTextBytes, 0, byteCount);
                        }
                    }
                }
            }
        }
    }
}
