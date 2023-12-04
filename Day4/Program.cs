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

    var cards = new List<Card>();
    foreach(var line in input)
    {
      cards.Add(new Card(line));
    }
    int amountOfCardTypes = cards.Count();
    int[] amountPerCards= new int[amountOfCardTypes];
    
    for(int i = 0; i< cards.Count();i++)
    {
      amountPerCards[i]=1;
    }
    for(int i = 0; i< cards.Count();i++)
    {
      for(int j=0; j< amountPerCards[i];j++)
      {
        int numberOfPairs = cards[i].GetNumberOfPairs();
        for(int k =1; k< numberOfPairs+1;k++)
        {
          amountPerCards[i+k]++;
        }
      }
    }
    int totalScratchCards = 0;
    for(int i = 0; i< cards.Count();i++)
    {
      totalScratchCards = totalScratchCards + amountPerCards[i];
    }
    Console.WriteLine($"{totalScratchCards} have won.");
  }

}

