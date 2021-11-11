
using Newtonsoft.Json;

namespace Client
{
    internal class DataAccess
    {

        //Write the message obj to the file in directory
        public void WriteMessage(string messagePath, Message EncryptedMessage)
        {
            if (File.Exists(messagePath))
            {
                File.Delete(messagePath);
            }

            var messageFolder = Path.GetDirectoryName(messagePath);

            if (!Directory.Exists(messageFolder))
            {
                Directory.CreateDirectory(messageFolder);
            }

            string message = JsonConvert.SerializeObject(EncryptedMessage);
            File.WriteAllText(messagePath, message);
        }


    }
}
