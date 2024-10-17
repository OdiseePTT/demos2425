using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncrypter
{
    internal class ReverseAlphabetEncryptor : IEncryptor
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string reverseAlphabet;

        public ReverseAlphabetEncryptor()
        {
            reverseAlphabet = new string(alphabet.ToArray().Reverse().ToArray());
        }

        public string Decrypt(string text)
        {
            return ReverseAlphabet(text);
        }

        public string Encrypt(string text)
        {
            return ReverseAlphabet(text);
        }

        private string ReverseAlphabet(string text)
        {
            string result = "";
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    bool isUpper = char.IsUpper(c);
                    int index = alphabet.IndexOf(char.ToLower(c));
                    result += isUpper ? char.ToUpper(reverseAlphabet[index]) : reverseAlphabet[index];
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }
    }
}
