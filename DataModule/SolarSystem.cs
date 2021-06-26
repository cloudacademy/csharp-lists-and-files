using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataModule
{
    public class SolarSystem
    {
        protected List<Planet> _planets;
        protected string _fileName;
        public SolarSystem()
        {
            
        }
        public SolarSystem(List<Planet> planets)
        {
            _planets = planets;
        }

        public List<Planet> Planets()
        {
            return _planets;
        }

        public override string ToString()
        {
            StringBuilder planets = new StringBuilder(_planets.Count);
            foreach(Planet p in _planets)
            {
                planets.Append(p.ToString() + Environment.NewLine);
            }
            return planets.ToString();
        }
        public void AddPlanet(Planet planet)
        {
            _planets.Add(planet);
        }

        public bool UpdatePlanet(string planetName, int distance)
        {
            bool planetFound = false;
            foreach (Planet p in _planets)
            {
                planetFound = p.Name.ToLower() == planetName.ToLower();
                if (planetFound)
                {
                    p.DistanceFromSun = distance;
                    break;
                }
            }
            return planetFound;
        }


    }
}
