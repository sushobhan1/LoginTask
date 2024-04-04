using System;
using System.Security.Cryptography;
using System.Text;


namespace DemoInfo.Security
{
    public class EncryptionDecryptionProvider
    {
        private RijndaelEncDec r { get; set; }
        public EncryptionDecryptionProvider()
        {
            r = new RijndaelEncDec();
        }
        public string EncryptText(string input)
        {
            if (input == "") return "";
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(EncryptionDecryptionKey.key);

            // Hash the password with SHA256
            using (SHA256 mySHA256 = SHA256.Create())
            {
                passwordBytes = mySHA256.ComputeHash(passwordBytes);
            }

            byte[] bytesEncrypted = r.AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        public string DecryptText(string input)
        {
            if (input == "") return "";
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(EncryptionDecryptionKey.key);

            using (SHA256 mySHA256 = SHA256.Create())
            {
                passwordBytes = mySHA256.ComputeHash(passwordBytes);
            }

            byte[] bytesDecrypted = r.AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            string result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }
    }
}