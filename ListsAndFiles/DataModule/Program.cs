using System;

namespace DataModule
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment the line below when running in Windows
            Data.Planets planetData = new Data.Planets($"{Environment.CurrentDirectory}\\DataFile\\planets.txt");

            // Uncomment the line below when running in Linux/MacOS
            //Data.Planets planetData = new Data.Planets($"{Environment.CurrentDirectory}/DataFile/planets.txt");
            
            SolarSystem solarSystem = new SolarSystem(planetData.GetAll());
            Console.Write(solarSystem.ToString());
            Console.WriteLine();

            Console.Write("Update planet's distance from sun. Enter planet name: ");
            string planetName = Console.ReadLine();
            Console.Write("Enter new distance from sun: ");
            string distance = Console.ReadLine();

            int km = 0;
            bool isInt = int.TryParse(distance, out km);

            if (isInt)
            {
                if (solarSystem.UpdatePlanet(planetName, km))
                {
                    planetData.SaveAll(solarSystem.Planets());
                    Console.WriteLine();
                    Console.Write(solarSystem.ToString());               
                }
                else
                {
                    Console.WriteLine($"{planetName} is not in the solar system");                  
                }
            }
            else 
            {
                Console.WriteLine($"{distance} is not an integer");
            }
           
        }
    }
}
