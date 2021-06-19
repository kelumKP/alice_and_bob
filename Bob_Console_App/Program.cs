using Service_App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bob_Console_App
{
    public class Program
    {
        // Reciever App
        public static void Main(string[] args)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            IEncryptDecryptService encDecSvc = new EncryptDecryptService();

            string bob_public_key_file_path = @"C:\Users\Kelum Rubasin\Documents\Visual Studio 2017\Projects\Alice_and_Bob\Bob_Console_App\keys\bob_public_key.txt";
            string bob_publicKey = File.ReadAllText(bob_public_key_file_path);

            string bob_private_key_file_path = @"C:\Users\Kelum Rubasin\Documents\Visual Studio 2017\Projects\Alice_and_Bob\Bob_Console_App\keys\bob_private_key.txt";
            string bob_privateKey = File.ReadAllText(bob_private_key_file_path);

            string encryptFilePath = @"C:\Users\Kelum Rubasin\Documents\Visual Studio 2017\Projects\Alice_and_Bob\Bob_Console_App\bin\Debug\encryptedData.dat";
            string encryptFile = File.ReadAllText(encryptFilePath); 

            if (string.IsNullOrEmpty(bob_publicKey) || string.IsNullOrEmpty(bob_privateKey))
            {
                bob_publicKey = rsa.ToXmlString(false);
                bob_privateKey = rsa.ToXmlString(true);

                File.WriteAllText(bob_public_key_file_path, bob_publicKey);
                File.WriteAllText(bob_private_key_file_path, bob_privateKey);
            }

            if (!String.IsNullOrEmpty(bob_privateKey) && !String.IsNullOrEmpty(encryptFile))
            {
                Console.WriteLine("Decrypted message: {0}", encDecSvc.DecryptData(bob_privateKey, encryptFilePath));
            }    
            else
            {
                if (String.IsNullOrEmpty(encryptFile))
                {
                    Console.WriteLine("Encryption File is Empty!");
                }
                if (String.IsNullOrEmpty(bob_privateKey))
                {
                    Console.WriteLine("Private Key Not Available!");
                }
            }
        }
    }
}
