using System.Security.Cryptography;


namespace Client
{
    internal class Hash
    {
        public byte[] HashSha256(byte[] toBeHashed)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(toBeHashed);
            }
        }
    }
}
