namespace Vote
{
    public class Person
    {
        #region Properties

        public int Age { get; set; }
        public bool CanVote { get => Age >= 18; }

        #endregion Properties
    }
}