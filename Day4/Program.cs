using CommonFunctions;
using System.Text.RegularExpressions;
using System;

class Program{
  static void Main()
  {
    var input = InputReader.ReadInData(InputType.Full);
    int score = 0;
    foreach(var line in input)
    {
      Console.WriteLine(line);
      var winningNumbers = GetWinningNumbers(line);
      var drawnNumbers = GetDrawnNumbers(line);

      var numberOfPairs = GetNumberOfPairs(winningNumbers, drawnNumbers);

      int cardScore = 1;
      if(numberOfPairs >0)
      {
        for(int i=1; i< numberOfPairs; i++)
        {
          cardScore = 2*cardScore;
        }
        score += cardScore;
      }
      
      var numberRegex = new Regex(@"\d+");
      var gameNumber = numberRegex.Match(line).Value;
      Console.WriteLine($"The score for game {gameNumber} is {cardScore}");
      
    }
    Console.WriteLine($"The hole score is {score}");
  }

    static int GetNumberOfPairs(List<int> winningNumbers, List<int> drawnNumbers)
    {
      int pairCounter = 0;
      foreach(var number in drawnNumbers)
      {
        if(winningNumbers.Contains(number))
        {
          pairCounter++;
          Console.Write($"{number} ");
        }
      }
      return pairCounter;
    }
    static List<int> GetWinningNumbers(string inputLine)
    {
      var winningNumbers = inputLine.Split(':')[1].Split('|')[0].Trim().Split(' ');
      return ParseNumbers(winningNumbers);
    }
    static List<int> GetDrawnNumbers(string inputLine)
    {
      var drawnNumbers = inputLine.Split(':')[1].Split('|')[1].Trim().Split(' ');
      return ParseNumbers(drawnNumbers);
    }
    static List<int> ParseNumbers(string[] numbers)
    {
      var numberList = new List<int>();
      foreach(var number in numbers)
      {
        if(!string.IsNullOrEmpty(number))
          numberList.Add(int.Parse(number));
      }
      return numberList;

    }
  }

