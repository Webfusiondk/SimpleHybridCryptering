

using System.Security.Cryptography;
using System.Text;

namespace Server
{
    internal class Hash
    {
        byte[] HashSha256(byte[] toBeHashed)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(toBeHashed);
            }
        }

        public bool CompareHash(byte[] messageHash, string messageToCompare)
        {
            byte[] temp = HashSha256(Encoding.UTF8.GetBytes(messageToCompare));

            if (messageHash.Length == temp.Length)
            {
                for (int i = 0; i < messageHash.Length; i++)
                {
                    if (messageHash[i] != temp[i])
                    {
                        return true;
                    }
                }
                return false;
            }
            return true;

        }
    }
}
