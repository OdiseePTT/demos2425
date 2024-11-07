namespace CodeCoverage
{
    public enum Graad
    {
        HoogsteOnderscheiding,
        Onderscheiding,
        Voldoende,
        Onvoldoende
    }

    public class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public bool IsGeslaagd()
        {
            if (Score >= 10)
            {
                return true;
            }

            return false;
        }

        public Graad GetGraad()
        {
            if (Score >= 18)
            {
                return Graad.HoogsteOnderscheiding;
            }
            else if (Score >= 14)
            {
                return Graad.Onderscheiding;
            }
            else if (Score >= 10)
            {
                return Graad.Voldoende;
            }
            else
            {
                return Graad.Onvoldoende;
            }
        }
    }
}
