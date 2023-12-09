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
      Console.WriteLine($"{extraPolateValue} is the extra polated value for the sequence {line}");
      result += extraPolateValue;

    }
    Console.WriteLine($"The summary of all the extra polated values is {result}");
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
    foreach(var number in substractedSequence)
    {
      Console.Write($"{number} ");
    }
    Console.Write("\n");
    var extraPolate = ExtraPolate(substractedSequence);
    Console.WriteLine($"Sub extra polated value is {extraPolate}");
    return sequence[sequence.Count()-1]+extraPolate; 
  }
}
