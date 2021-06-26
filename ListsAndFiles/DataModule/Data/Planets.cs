using System;
using System.Collections.Generic;
using System.IO;

namespace DataModule.Data
{
    public class Planets  
    {
        private string _fileName;

        public Planets()
        {  
        }
        public Planets(string fileName)
        {
            _fileName = fileName;
        }  

        public List<Planet> GetAll()
        {
            List<Planet> planets =  new List<Planet>();
            string[] planetArray = File.ReadAllLines(_fileName);
            planets = new List<Planet>(planetArray.Length);
            for (int i = 0; i < planetArray.Length; i++)
            {
                string[] planetStr = planetArray[i].Split(',');
                planets.Add(new Planet(planetStr[0], Convert.ToInt32(planetStr[1])));
            }
            return planets;
        }     

        public void SaveAll (List<Planet> planets)
        {
            string[] planetArray = new string[planets.Count];
            for (int i = 0; i < planets.Count; i++)
            {
                planetArray[i] = $"{planets[i].Name},{planets[i].DistanceFromSun}";
            }
            File.WriteAllLines(_fileName, planetArray);           
        }
    }
}