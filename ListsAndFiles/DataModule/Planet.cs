
namespace DataModule
{
    public class Planet
    {
        public string Name { get; set; }
        public int DistanceFromSun { get; set; }
        public Planet(string name)
        {
            Name = name;
        }

        public Planet(string name, int distance)
        {
            Name = name;
            DistanceFromSun = distance;
        }

        public override string ToString()
        {
            return $"{Name} is {DistanceFromSun} millions of km from sun";
        }

    }
}