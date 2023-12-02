using System.Text.RegularExpressions;
using System;
using System.Runtime;

namespace Day2{
    internal class Game
    {
        public Game(string gameRecord)
        {
            InitializeGameNumber(gameRecord);
            InitializeSets(gameRecord);
        }
        public int GameNumber;
        public List<Set> Sets = new List<Set>();

        private void InitializeGameNumber(string gameRecord)
        {
            var numberRegex = new Regex(@"\d+");
            GameNumber = int.Parse(numberRegex.Match(gameRecord).Value);
        }
        private void InitializeSets(string gameRecord)
        {
            var sets = gameRecord.Replace(" ","").Split(":")[1].Split(";");
            foreach(var set in sets)
            {
                var cubes = GetNumberOfCubes(set);
                Sets.Add( new Set(cubes.NumberOfReds, cubes.NumberOfGreens, cubes.NumberOfBlues));
            }
        }
        private (int NumberOfGreens, int NumberOfReds, int NumberOfBlues) GetNumberOfCubes(string set)
        {
            var cubeColorAndAmount = set.Split(",");
            var numberRegex = new Regex(@"\d+");
            int numberOfGreens = 0; 
            int numberOfBlues = 0; 
            int numberOfReds = 0; 
            foreach(var color in cubeColorAndAmount)
            {
                if(color.Contains("green")){
                    numberOfGreens = int.Parse(numberRegex.Match(color).Value);
                }
                if(color.Contains("red")){
                    numberOfReds = int.Parse(numberRegex.Match(color).Value);
                }
                if(color.Contains("blue")){
                    numberOfBlues = int.Parse(numberRegex.Match(color).Value);
                }
            }
            return (numberOfGreens, numberOfReds, numberOfBlues);
        }
    }
}