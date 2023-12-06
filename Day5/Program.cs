using CommonFunctions;
using System.Text.RegularExpressions;
using System;
using Day5;

class Program{
  static void Main()
  {
    var input = InputReader.ReadInData(InputType.Full).ToList();
    foreach(var line in input)
    {
      Console.WriteLine(line);
    }
    var seeds = GetSeeds(input[0]);
    input.RemoveAt(0);
    input.RemoveAt(0);

    var converters = ConverterFactory.CreateMaps(input.ToList());

    var locations = new List<long>();
    foreach(var seed in seeds)
    {
      long temp = seed;
      foreach(var converter in converters)
      {
        temp = converter.Convert(temp);
      }
      locations.Add(temp);
    }
    var lowestLocationNumber = locations.Min();
    Console.WriteLine($"The lowest location is {lowestLocationNumber}");
  }

  static List<long> GetSeeds(string input)
  {
    var seedsLine = input.Split(':')[1];
    var digitRegex = new Regex(@"\d+");
    var matches = digitRegex.Matches(seedsLine);

    var seeds = new List<long>();
    foreach(Match match in matches)
    {
      seeds.Add(long.Parse(match.Value));
    }
    return seeds;
  }
}
