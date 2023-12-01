using CommonFunctions;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program{
  static void Main()
  {
    var input = InputReader.ReadInData(InputType.Full);
    int calibrationValueSum = 0;
    //The ExampleInput changed for puzzle 1 and 2. 
    //For getting the input for the first puzzle use git
    /*foreach(var line in input)
    {
      string numberSearch = "[0-9]";
      var matches = Regex.Matches(line,numberSearch);
      string calibrationValue = matches[0].Value + matches[matches.Count-1].Value;
      Console.WriteLine($"The calibrationvalue is {calibrationValue}");
      calibrationValueSum += int.Parse(calibrationValue);
    }
    Console.WriteLine($"The sum of all the calibration values is {calibrationValueSum}");
    */


    //puzzle 2
    var numberDictonary = new Dictionary<string, string>(){
      ["one"]="1",
      ["two"]="2",
      ["three"]="3",
      ["four"]="4",
      ["five"]="5",
      ["six"]="6",
      ["seven"]="7",
      ["eight"]="8",
      ["nine"]="9"

    };
    foreach(var line in input)
    {
      var numberSearchFirstDigit = new Regex("[0-9]|one|two|three|four|five|six|seven|eight|nine");
      var numberSearchLastDigit = new Regex("([0-9]|one|two|three|four|five|six|seven|eight|nine)",RegexOptions.RightToLeft);
      var matchesFirstDigit = numberSearchFirstDigit.Matches(line);
      var matchesLastDigit = numberSearchLastDigit.Matches(line);
      string firstNumber = Regex.IsMatch(matchesFirstDigit[0].Value,"[0-9]")? matchesFirstDigit[0].Value: numberDictonary[matchesFirstDigit[0].Value];
      string lastNumber = Regex.IsMatch(matchesLastDigit[0].Value,"[0-9]")? matchesLastDigit[0].Value: numberDictonary[matchesLastDigit[0].Value];
      string calibrationValue = firstNumber + lastNumber;
      Console.WriteLine($"The calibrationvalue is {calibrationValue} from {firstNumber} and {lastNumber}");
      calibrationValueSum = checked(calibrationValueSum + int.Parse(calibrationValue));
    }
    Console.WriteLine($"The sum of all the calibration values is {calibrationValueSum}");
  }
}
