using CommonFunctions;
using System;
using System.Text.RegularExpressions;

class Program{
  static void Main()
  {
    var input = InputReader.ReadInData(InputType.Full);
    foreach(var line in input)
    {
      Console.WriteLine(line);
    }
    long result=0;
    foreach(var line in input)
    {
      var digitRegex = new Regex(@"[-]?\d+");
      var sequence = digitRegex.Matches(line).Select(x => long.Parse(x.Value)).ToList();
      var extraPolateValue = ExtraPolate(sequence);
      result += extraPolateValue;

    }
    Console.WriteLine($"The summary of all the extra polated values is {result}");

    result=0;
    foreach(var line in input)
    {
      var digitRegex = new Regex(@"[-]?\d+");
      var sequence = digitRegex.Matches(line).Select(x => long.Parse(x.Value)).ToList();
      var extraPolateValue = ExtraPolateAtBeginning(sequence);
      result += extraPolateValue;
    }
    Console.WriteLine($"The summary of all the extra polated values at the beginning is {result}");
  }
  private static long ExtraPolate(List<long> sequence)
  {
    if(sequence.All(x=>x==0))
      return 0;
    var substractedSequence = new List<long>();
    for(int i = 0; i< sequence.Count()-1; i++)
    {
      substractedSequence.Add(sequence[i+1]-sequence[i]);
    }
    var extraPolate = ExtraPolate(substractedSequence);
    return sequence[sequence.Count()-1]+extraPolate; 
  }
  private static long ExtraPolateAtBeginning(List<long> sequence)
  {
    if(sequence.All(x=>x==0))
      return 0;
    var substractedSequence = new List<long>();
    for(int i = 0; i< sequence.Count()-1; i++)
    {
      substractedSequence.Add(sequence[i+1]-sequence[i]);
    }
    var extraPolate = ExtraPolateAtBeginning(substractedSequence);
    return sequence[0]-extraPolate; 
  }
}
