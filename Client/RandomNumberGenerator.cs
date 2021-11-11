using System.Security.Cryptography;

namespace Client
{
    internal class RandomNumberGenerator
    {
        //Generate random numbers that we return in byte array
        public byte[] Generate(int length)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                rng.GetBytes(randomNumber);

                return randomNumber;
            }
        }
    }
}
