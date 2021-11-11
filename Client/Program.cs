using Client;
using System.Text;

RandomNumberGenerator randomNumber = new RandomNumberGenerator();
Hash hash = new Hash();
Encrypt AES = new Encrypt();
RSA rsa = new RSA();
DataAccess da = new DataAccess();

string text = "Big dick joe";
const string publicKeyPath = @"C:\RSAKeys\PublicKey\Client1PublicKey.xml";
const string serverPublicKeyPath = @"C:\RSAKeys\PublicKey\Client2PublicKey.xml";
const string privateKeyPath = @"C:\RSAKeys\PrivateKey\Client1PrivateKey.xml";
const string messagePath = @"C:\RSAKeys\EncryptedMessage\Message.xml";
byte[] aesKey = randomNumber.Generate(32);
byte[] aesIv = randomNumber.Generate(16);
byte[] textHash = hash.HashSha256(Encoding.UTF8.GetBytes(text));
byte[] aesEncrypted = AES.AesEncrypt(Encoding.UTF8.GetBytes(text), aesKey, aesIv);

rsa.AssignNewKey(publicKeyPath, privateKeyPath);
byte[] rsaEncrypted = rsa.Encrypt(serverPublicKeyPath, aesEncrypted);
da.WriteMessage(messagePath,new Message(rsaEncrypted,aesKey,aesIv,textHash));
Console.WriteLine("Message created in directory");
Console.ReadLine();