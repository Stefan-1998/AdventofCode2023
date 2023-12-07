using CommonFunctions;
using System.Text.RegularExpressions;
using System;
using Day5;

class Program{
  static void Main()
  {
    var input = InputReader.ReadInData(InputType.Example).ToList();
    foreach(var line in input)
    {
      Console.WriteLine(line);
    }
    var seeds = GetSeeds(input[0]);
    var seedRanges = GetSeedRanges(input[0]);
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

    //puzzle 2
    /*var results = new List<(long StartPoint, long Range)>();
    foreach((long StartPoint, long Range) seedRange in seedRanges)
    {
      var convertedSeedRanges = new List<(long StartPoint, long Range)>(){seedRange};
      foreach(var converter in converters)
      {

        //var normalList = converter.GetNotConvertedRanges(seedRange.StartPoint, seedRange.Range);
        var convertedList = converter.ConvertRanges(seedRange.StartPoint, seedRange.Range);
        convertedSeedRanges = normalList.Concat(convertedList).ToList();
      }
      results = results.Concat(convertedSeedRanges).ToList();

    }
    var minValue = results.Min(t => t.StartPoint);
    Console.WriteLine($"The minimum is {minValue}");*/
    Solution2();
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
  static List<(long StartPoint,long Range)> GetSeedRanges(string input)
  {
    var seedsLine = input.Split(':')[1];
    var digitRegex = new Regex(@"\d+");
    var matches = digitRegex.Matches(seedsLine);

    var seedRanges = new List<(long StartPoint, long Range)>();
    for(int i=0; i< matches.Count();i=i+2)
    {
      seedRanges.Add((StartPoint: long.Parse(matches[i].Value), Range: long.Parse(matches[i+1].Value)));
    }
    return seedRanges;

  }
  static void Solution2()
        {
            string[] lines = File.ReadAllLines(@"./Input.txt");

            List<(long, long)> seedRanges = new();
            var seedsRangesInput = lines[0].Split().Where(x => x != string.Empty && x != "seeds:").Select(x => long.Parse(x)).ToList();
            for (int i = 0; i < seedsRangesInput.Count; i+=2)
            {
                seedRanges.Add((seedsRangesInput[i], seedsRangesInput[i + 1]));
            }

            List<(long, long)> seedRangesChanged = new();
            List<(long, long)> seedRangesTemp = new();

            foreach (var line in lines[1..])
            {
                seedRangesTemp = new();
                if (line == "" || line.Contains("map"))
                {
                    foreach(var seedRange in seedRangesChanged)
                        seedRanges.Add((seedRange.Item1, seedRange.Item2));
                    seedRangesChanged = new();
                    continue;
                }

                var map = line.Split().Where(x => x != string.Empty).Select(x => long.Parse(x)).ToList();
                foreach (var seedRange in seedRanges)
                {
                    var rangeStart = map[1];
                    var rangeStop = map[1] + map[2] - 1;
                    var shift = map[0] - map[1];

                    var seedStart = seedRange.Item1;
                    var seedStop = seedRange.Item1 + seedRange.Item2 - 1;

                    long commonRangeStart = 0;
                    long commonRangeStop = 0;

                    if (rangeStart < seedStart && rangeStop >= seedStart & rangeStop <= seedStop)
                    {
                        commonRangeStart = seedStart;
                        commonRangeStop = rangeStop;
                        seedRangesChanged.Add((commonRangeStart + shift, commonRangeStop - commonRangeStart + 1));
                        if (commonRangeStop + 1 <= seedStop)
                            seedRangesTemp.Add((commonRangeStop + 1, seedStop - (commonRangeStop + 1) + 1));
                    }
                    else if (rangeStart >= seedStart && rangeStop <= seedStop)
                    {
                        commonRangeStart = rangeStart;
                        commonRangeStop = rangeStop;
                        seedRangesChanged.Add((commonRangeStart + shift, commonRangeStop - commonRangeStart + 1));
                        if (commonRangeStop + 1 <= seedStop)
                            seedRangesTemp.Add((commonRangeStop + 1, seedStop - (commonRangeStop + 1) + 1));
                        if (commonRangeStart - 1 >= seedStart)
                            seedRangesTemp.Add((seedStart, commonRangeStart - 1 - (seedStart) + 1));
                    }
                    else if(rangeStart >= seedStart && rangeStart <= seedStop && rangeStop > seedStop)
                    {
                        commonRangeStart = rangeStart;
                        commonRangeStop = seedStop;
                        seedRangesChanged.Add((commonRangeStart + shift, commonRangeStop - commonRangeStart + 1));
                        if (commonRangeStart - 1 >= seedStart)
                            seedRangesTemp.Add((seedStart, commonRangeStart - 1 - (seedStart) + 1));
                    }
                    else if (rangeStart < seedStart && rangeStop > seedStop)
                    {
                        commonRangeStart = seedStart;
                        commonRangeStop = seedStop;
                        seedRangesChanged.Add((commonRangeStart + shift, commonRangeStop - commonRangeStart + 1));
                    }
                    else
                    {
                        seedRangesTemp.Add((seedStart, seedStop - seedStart + 1));
                    }
                }

                seedRanges = seedRangesTemp;
            }

            foreach (var seedRange in seedRangesChanged)
                seedRanges.Add((seedRange.Item1, seedRange.Item2));

            Console.WriteLine(seedRanges.Min(x => x.Item1));
        }
}
