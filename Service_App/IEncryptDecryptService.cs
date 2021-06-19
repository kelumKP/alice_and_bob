using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_App
{
    public interface IEncryptDecryptService
    {
        string EncryptText(string receiver_publicKey, string text, string encryptFileName);
        string DecryptData(string reciever_privateKey, string encryptFileName);         
    }
}
