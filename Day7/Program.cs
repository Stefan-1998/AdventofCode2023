using CommonFunctions;
using System;

class Program{
  static void Main()
  {
    var input = InputReader.ReadInData(InputType.Example);
    foreach(var line in input)
    {
      Console.WriteLine(line);
    }
    var cardWithBids = new List<(string Cards, int Bids)>();
    foreach(var line in input)
    {
      var cards = line.Split(' ')[0];
      var bids = int.Parse(line.Split(' ')[0]);
      cardWithBids.Add((Cards: cards, Bids: bids));

    }

  }
}
