using System;

namespace FileReadWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment the line below when running in Windows
            SolarSystem solarSystem = new SolarSystem($"{Environment.CurrentDirectory}\\Data\\planets.txt");

            // Uncomment the line below when running in Linux/MacOS
            //SolarSystem solarSystem = new SolarSystem($"{Environment.CurrentDirectory}/Data/planets.txt");
            
            Console.Write(solarSystem.ToString());
            Console.WriteLine();        
        }
    }
}
