namespace Car
{

    public enum Transmission
    {
        MANUAL,
        AUTOMATIC
    }
    public class Car: IComparable<Car>, IFormattable, IEquatable<Car>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int ConstructionYear { get; set; }
        public double Price { get; set; }
        public Transmission Transmission { get; set; }

        public Car(string make, string model, int constructionYear, double price, Transmission transmission)
        {
            Make = make;
            Model = model;
            ConstructionYear = constructionYear;
            Price = price;
            Transmission = transmission;
        }

        public override string ToString()
        {
            return $"{Make} {Model} {Transmission} - {ConstructionYear} €{Price}";
        }

        public int CompareTo(Car? other)
        {
            // -1 => this > other
            // 0 => this == other
            // 1 => this < other
            return Price.CompareTo(other.Price);
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Car? other)
        {
            throw new NotImplementedException();
        }
    }
}
