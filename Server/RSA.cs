

using System.Security.Cryptography;

namespace Server
{
    internal class RSA
    {

        //Decrypt the encrypted message with the private key
        public byte[] Decrypt(string privateKeyPath, byte[] dataToEncrypt)
        {
            byte[] plain;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(privateKeyPath));
                plain = rsa.Decrypt(dataToEncrypt, false);
            }

            return plain;
        }
    }
}
