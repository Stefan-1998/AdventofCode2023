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
      if(partNumber.IsAdjacentToSpecialCharacter(specialCharacterPositions))
      {
        sumOfPartNumbers += partNumber.Number;
      }
    }
    Console.WriteLine($"The sum of all the valid partNumbers is {sumOfPartNumbers}");

    //puzzle 2
    var gearCharacterPositions = GetGearCharacterPositions(input);
    
    var gears = partNumbers.Where(t => t.IsAdjacentToSpecialCharacter(gearCharacterPositions)).ToList();
    var sumOfGearRatios = GetSumOfGearRations(gears, gearCharacterPositions);
    Console.WriteLine($"The sum of all the gearratios is {sumOfGearRatios}");

  }
  static int GetSumOfGearRations(List<PartNumber> gears, List<(int Line, int Position)> gearCharacters)
  {
    int sumOfGearRatios = 0; 
    foreach(var gearCharacter in gearCharacters)
    {
      int connectedGears = 0;
      int gearRatio = 1;
      foreach(var gear in gears)
      {
        if(gear.IsAdjacentToSpecialCharacter(new List<(int Line, int Position)>(){gearCharacter}))
        {
          connectedGears ++;
          gearRatio *= gear.Number;
        }
      }
      if(connectedGears >1)
      {
        sumOfGearRatios += gearRatio;
        Console.WriteLine($"Two gears found with the gearration {gearRatio}");
      }
    }

    return sumOfGearRatios;
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
          if(input[i][j]== '*')
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
