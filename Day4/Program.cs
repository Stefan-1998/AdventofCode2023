using CommonFunctions;
using System;
using Day4;

class Program{
  static void Main()
  {
    var input = InputReader.ReadInData(InputType.Full);
    int score = 0;
    foreach(var line in input)
    {
      Console.WriteLine(line);
      var card = new Card(line);

      var numberOfPairs = card.GetNumberOfPairs();

      score += card.GetCardScore(); 
      Console.WriteLine($"The score for game {card.Number} is {card.GetCardScore()}");
      
    }
    Console.WriteLine($"The hole score is {score}");

    //puzzle 2
  }

}

