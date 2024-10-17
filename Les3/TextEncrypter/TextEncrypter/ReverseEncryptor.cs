using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncrypter
{
    internal class ReverseEncryptor : IEncryptor
    {
        public string Decrypt(string text)
        {
            return Reverse(text);
        }

        public string Encrypt(string text)
        {
            return Reverse(text);
        }

        private string Reverse(string text)
        {
            return new string(text.ToArray().Reverse().ToArray());
        }
    }
}
