using Server;
using System.Text;

DataAccess da = new DataAccess();
RSA rsa = new RSA();
Decrypt ASE = new Decrypt();
Hash hash = new Hash();

const string publicKeyPath = @"C:\RSAKeys\PublicKey\Client2PublicKey.xml";
const string privateKeyPath = @"C:\RSAKeys\PrivateKey\Client2PrivateKey.xml";
string messagePath = @"C:\RSAKeys\EncryptedMessage\Message.xml";
Message message = da.ReadMessage(messagePath);
//da.AssignNewKey(publicKeyPath, privateKeyPath);
byte[] decryptedMessage = ASE.AesDecrypt(rsa.Decrypt(privateKeyPath, message.EncryptedMessage), message.Key,message.Iv);
UI();
Console.ReadLine();


void UI()
{
    Console.WriteLine("Decrypted message");
    Console.WriteLine($"Plane text: {Encoding.UTF8.GetString(decryptedMessage)}");
    Console.WriteLine($"Was message changed threw travel: {hash.CompareHash(message.Hash,Encoding.UTF8.GetString(decryptedMessage))}");
}