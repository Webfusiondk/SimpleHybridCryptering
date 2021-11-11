
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Server
{
    internal class DataAccess
    {

        public Message ReadMessage(string messagePath)
        {
            Message deserilizedMessage = JsonConvert.DeserializeObject<Message>(File.ReadAllText(messagePath));
            return deserilizedMessage;
        }

        public void AssignNewKey(string publicKeyPath, string privateKeyPath)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                if (File.Exists(privateKeyPath))
                {
                    File.Delete(privateKeyPath);
                }

                if (File.Exists(publicKeyPath))
                {
                    File.Delete(publicKeyPath);
                }

                var publicKeyfolder = Path.GetDirectoryName(publicKeyPath);
                var privateKeyfolder = Path.GetDirectoryName(privateKeyPath);

                if (!Directory.Exists(publicKeyfolder))
                {
                    Directory.CreateDirectory(publicKeyfolder);
                }

                if (!Directory.Exists(privateKeyfolder))
                {
                    Directory.CreateDirectory(privateKeyfolder);
                }

                File.WriteAllText(publicKeyPath, rsa.ToXmlString(false));
                File.WriteAllText(privateKeyPath, rsa.ToXmlString(true));
            }
        }
    }
}
