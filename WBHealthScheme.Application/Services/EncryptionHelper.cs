using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WBHealthScheme.Application.Services
{
    public class EncryptionHelper
    {
        public static string Encrypt(string plainText, string key) 
            /// plainText → data you want to protect
            ///key → secret used for encryption
        {
            using var aes = Aes.Create();
            /* 👉 Creates an AES encryption engine
            AES = standard symmetric encryption algorithm
            Works with key + IV */
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32));
            /* 👉 Important line
                What happens:
                PadRight(32) → makes key exactly 32 characters
                GetBytes() → converts string → byte array
                👉 Why 32?
                AES-256 needs 32 bytes key*/
            aes.IV = new byte[16];
            /* 👉 IV = random value used in encryption
                But here:
                It is set to all zeros
                IV should be random for every encryption*/

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            /* 👉 This prepares the encryption logic using: Key & IV*/

            using var ms = new MemoryStream();
            /*👉 This will store encrypted bytes in memory*/
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            /*👉 This connects: Your data → encryption → memory stream
                    Plain Text → CryptoStream → Encrypted Bytes → MemoryStream*/
            using var sw = new StreamWriter(cs);
            /*👉 Allows writing string data into CryptoStream*/

            sw.Write(plainText);
            /*👉 This is where text gets encrypted,
                  Result goes into MemoryStream as bytes*/

            return Convert.ToBase64String(ms.ToArray());
            /* 👉 Why Base64?
                Encrypted data = binary (not readable)
                Base64 = safe string format for: APIs, JSON, DB storage*/
        }

    public static string Decrypt(string cipherText, string key)
    {
        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32));
        aes.IV = new byte[16];

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);

        return sr.ReadToEnd();
    }
    
    }
}