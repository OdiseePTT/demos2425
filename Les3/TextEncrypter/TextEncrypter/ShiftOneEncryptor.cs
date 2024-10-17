namespace TextEncrypter
{
    internal class ShiftOneEncryptor : IEncryptor
    {
        public string Encrypt(string text)
        {
            string result = "";
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char newChar;
                    if (c == 'Z')
                    {
                        newChar = 'A';
                    }
                    else if (c == 'z')
                    {
                        newChar = 'a';
                    }
                    else
                    {
                        newChar = (char)(c + 1);
                    }

                    result += newChar;
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }

        public string Decrypt(string text)
        {
            return new string(text.Select(c =>
            {
                if (char.IsLetter(c))
                {
                    char newChar;
                    if (c == 'A')
                    {
                        newChar = 'Z';
                    }
                    else if (c == 'a')
                    {
                        newChar = 'z';
                    }
                    else
                    {
                        newChar = (char)(c - 1);
                    }

                    return newChar;
                }
                else
                {
                    return c;
                }
            }).ToArray());
        }
    }
}
