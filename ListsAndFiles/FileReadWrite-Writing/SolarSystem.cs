using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileReadWrite
{
    public class SolarSystem
    {
        protected List<Planet> _planets;
        protected string _fileName;
        public SolarSystem()
        {
            
        }
        public SolarSystem(string fileName)
        {
            ReadFromFile(fileName);
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
        public void ReadFromFile(string fileName)
        {
            _fileName = fileName;
            string[] planets = File.ReadAllLines(fileName);
            _planets = new List<Planet>(planets.Length);
            for (int i = 0; i < planets.Length; i++)
            {
                string[] planetStr = planets[i].Split(',');
                AddPlanet(new Planet(planetStr[0], Convert.ToInt32(planetStr[1])));
            }
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
            if (planetFound)
                Save();
            return planetFound;
        }
        public void Save()
        {
            string[] planets = new string[_planets.Count];
            for (int i = 0; i < _planets.Count; i++)
            {
                planets[i] = $"{_planets[i].Name},{_planets[i].DistanceFromSun}";
            }
            File.WriteAllLines(_fileName, planets);
        }
    }
}