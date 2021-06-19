using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service_App
{
    public class EncryptDecryptService : IEncryptDecryptService
    {
        public string EncryptText(string receiver_publicKey, string text, string encryptFileName)
        {
            string result = "";
            try
            {
                UnicodeEncoding byteConverter = new UnicodeEncoding();

                byte[] dataToEncrypt = byteConverter.GetBytes(text);
                byte[] encryptedData;
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(receiver_publicKey);
                    encryptedData = rsa.Encrypt(dataToEncrypt, false);
                    File.WriteAllBytes(encryptFileName, encryptedData);
                    string encryptedText = Encoding.UTF8.GetString(encryptedData);
                }

                result = "Data has been encrypted";  
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }                  
        }
        public string DecryptData(string reciever_privateKey, string encryptFileName)
        {
            try
            {
                byte[] dataToDecrypt = File.ReadAllBytes(encryptFileName);
                byte[] decryptedData;
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(reciever_privateKey);
                    decryptedData = rsa.Decrypt(dataToDecrypt, false);
                }

                UnicodeEncoding byteConverter = new UnicodeEncoding();
                var decryptedString = byteConverter.GetString(decryptedData);

                return decryptedString;
            }
            catch (Exception ex)
            {   
                throw ex;
            }


        }    

    }
}
