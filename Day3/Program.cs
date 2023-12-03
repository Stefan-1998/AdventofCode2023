using CommonFunctions;
using System;
using Day3;

class Program{
  static void Main()
  {
    
    var input = InputReader.ReadInData(InputType.Full).ToList();

    //puzzle 1
    int sumOfPartNumbers = 0;
    var specialCharacterPositions = GetSpecialCharacterPositions(input);
    var partNumbers = GetPartNumbers(input);
    foreach(var partNumber in partNumbers)
    {
      if(partNumber.IsValidPartNumber(specialCharacterPositions))
      {
        sumOfPartNumbers += partNumber.Number;
      }
    }
    Console.WriteLine($"The sum of all the valid partNumbers is {sumOfPartNumbers}");

    //puzzle 2
    var gearCharacterPositions = GetGearCharacterPositions(input);

  }
  static List<(int Line, int Position)> GetSpecialCharacterPositions(List<string> input)
  {
    var specialCharacterPositions = new List<(int Line, int Position)>();
    for(int i = 0; i< input.Count(); i++)
    {
        for(int j = 0; j< input[i].Length; j++)
        {
          if(char.IsLetter(input[i][j]))
            continue;
          if(char.IsNumber(input[i][j]))
            continue;
          if(input[i][j]== '.')
            continue;
          specialCharacterPositions.Add((Line: i, Position: j));
        }
    }
    return specialCharacterPositions;
  }
  static List<(int Line, int Position)> GetGearCharacterPositions(List<string> input)
  {
    var specialCharacterPositions = new List<(int Line, int Position)>();
    for(int i = 0; i< input.Count(); i++)
    {
        for(int j = 0; j< input[i].Length; j++)
        {
          if(input[i][j]== "*")
            specialCharacterPositions.Add((Line: i, Position: j));
        }
    }
    return specialCharacterPositions;
  }
  static List<PartNumber> GetPartNumbers(List<string> input)
  {
    var partNumbers = new List<PartNumber>();
    for(int i = 0; i< input.Count(); i++)
    {
        var partNumberList = PartNumberFactory.CreatePartNumber(i, input[i]);
        foreach(var partNumber in partNumberList)
        {
          Console.WriteLine($"{partNumber.Number}");
          partNumbers.Add(partNumber);
          
        }
    }
    return partNumbers;
  }
}
