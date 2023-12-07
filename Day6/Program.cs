using CommonFunctions;
using System;
using System.Text.RegularExpressions;

class Program{
  static void Main()
  {
    var input = InputReader.ReadInData(InputType.Full).ToList();
    foreach(var line in input)
    {
      Console.WriteLine(line);
    }
    var digitRegex = new Regex(@"\d+");
    var times = digitRegex.Matches(input[0]).Select(x => long.Parse(x.Value)).ToList();
    var distances = digitRegex.Matches(input[1]).Select(x => long.Parse(x.Value)).ToList();
    CalculatePossibleWins(times, distances);

    var singleTime = digitRegex.Matches(input[0].Replace(" ","")).Select(x => long.Parse(x.Value)).ToList();
    var singleDistance = digitRegex.Matches(input[1].Replace(" ","")).Select(x => long.Parse(x.Value)).ToList();
    CalculatePossibleWins(singleTime, singleDistance);
}

static void CalculatePossibleWins(List<long> times, List<long> distances)
{
    long raceSummary =1;
    for(int i=0; i<times.Count(); i++)
    {
      int wonRaces =0;
      var raceTime = times[i];
      var raceDistance = distances[i];
      for(long j=0; j< raceTime; j++)
      {
        long distance = j* (raceTime-j);
        if(distance>raceDistance)
          wonRaces++;
      }
      Console.WriteLine($"There are {wonRaces} posibilities for winning the race with the distance {raceDistance} and the time {raceTime}");
      raceSummary=raceSummary*wonRaces;
    }
    Console.WriteLine($"The product of all the possible wins is {raceSummary}");
  }
}