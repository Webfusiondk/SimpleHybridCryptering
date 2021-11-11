using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Message
    {
        public byte[] EncryptedMessage { get; set; }
        public byte[] Key { get; set; }
        public byte[] Iv { get; set; }
        public byte[] Hash { get; set; }
        
        public Message(byte[] message, byte[] key, byte[] iv, byte[] hash)
        {
            EncryptedMessage = message;
            Key = key;
            Iv = iv;
            Hash = hash;
        }
    }
}
