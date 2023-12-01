using CommonFunctions;
using System;
using System.Text.RegularExpressions;

class Program{
  static void Main()
  {
    var input = InputReader.ReadInData(InputType.Full);
    int calibrationValueSum = 0;
    foreach(var line in input)
    {
      string numberSearch = "[0-9]";
      var matches = Regex.Matches(line,numberSearch);
      string calibrationValue = matches[0].Value + matches[matches.Count-1].Value;
      Console.WriteLine($"The calibrationvalue is {calibrationValue}");
      calibrationValueSum += int.Parse(calibrationValue);
    }
    Console.WriteLine($"The sum of all the calibration values is {calibrationValueSum}");
  }
}
