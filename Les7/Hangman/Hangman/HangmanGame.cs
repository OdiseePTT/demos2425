using Hangman.Repositories;

namespace Hangman
{
    public class HangmanGame
    {
        public string TeRadenWoord {
            get
            {
                return new string(
                    randomWoord.Select(letter => letters.Contains(letter) ? letter: '_').ToArray());
            }
        }
        public int Levens { get; private set; } = 10;

        private string randomWoord;
        private List<char> letters = new List<char>();

        public HangmanGame(IWoordRepository woordRepository)
        {
            randomWoord = woordRepository.GetRandomWoord();
    
            //foreach(char c in randomWoord)
            //{
            //    TeRadenWoord += "_";
            //}
        }

        public GameStatus RaadLetter(char c)
        {
            //int index = 0;
            //foreach(char letter in randomWoord)
            //{
            //    if(letter == c)
            //    {
            //        char[] temp = TeRadenWoord.ToCharArray();
            //        temp[index] = c;
            //        TeRadenWoord = new string(temp);
            //    } 
            //    index++;

            //}

          

            if (letters.Contains(c))
            {
                return GameStatus.AlGeraden;
            }

            letters.Add(c);

            if (randomWoord.Contains(c))
            {
                return GameStatus.LetterAanwezig;
            } else
            {
                Levens -= 1;
                return GameStatus.LetterAfwezig;
            }
        }
    }
}
