using CommonFunctions;
using System.Collections.Generic; 
using System;
using System.Runtime.CompilerServices;

class Program{
  static void Main()
  {
    var input = InputReader.ReadInData(InputType.Full);
    foreach(var line in input)
    {
      Console.WriteLine(line);
    }
    var cardWithBids = new List<(string Cards, int Bid)>();
    foreach(var line in input)
    {
      var cards = line.Split(' ')[0];
      var bid = int.Parse(line.Split(' ')[1]);
      cardWithBids.Add((Cards: cards, Bid: bid));

    }
    
    cardWithBids.Sort(SortByPokerRules);
    
    foreach(var cards in cardWithBids)
    {
      Console.WriteLine($"{cards.Cards}");

    }

    long totalWinnings =0;
    for(int i = 1; i <= cardWithBids.Count; i++)
    {
      checked{totalWinnings+= i*cardWithBids[i-1].Bid;}
    }
    Console.WriteLine($"The total whinning is {totalWinnings}");
    //liste einlesen mit tuple
    //Anzahl der Karten kann ich leicht mit einer map feststellen
    //Liste einfach sortieren mit einer function
    //einfach 100 mal sortieren
    //Kartenwert kann ich mit der Position in einer Liste rausfinden
    //Kartenwert ist zweitranging -> Kombinationen wie Full House sind immer wichtiger

  }
  public static readonly List<char> CardPossibilities = new List<char>(){'2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
  public static int SortByPokerRules((string Cards, int Bid) firstHand, (string Cards, int Bid) secondHand)
  {
    //return 0 => equal
    //return 1 => firstHand
    //return -1 => secondHand
    int firstHandType = GetHandType(firstHand.Cards);
    int secondHandType = GetHandType(secondHand.Cards);
    if(firstHandType > secondHandType)
      return 1;
    if(firstHandType < secondHandType)
      return -1;

    for(int i =0; i< 5; i++)
    {
      var firstCardValue = CardPossibilities.FindIndex(t => t == firstHand.Cards[i]);
      var secondCardValue = CardPossibilities.FindIndex(t => t == secondHand.Cards[i]);
      if(firstCardValue > secondCardValue)
        return 1;
      if(firstCardValue < secondCardValue)
        return -1;
    }
    return 0;
  }
  //5 of a kind => 7
  //4 of a kind => 6
  //full House  => 5
  //3 of a kind => 4
  //2 pairs => 3
  //1 pairs => 2
  //high card => 1
  public static int GetHandType(string cards)
  {
    Dictionary<char,int> cardTypes = new Dictionary<char,int>();
    foreach(char card in cards)
    { 
      if(cardTypes.ContainsKey(card))
      {
        cardTypes[card]++;
      }
      else{
        cardTypes[card]=1;
      }

    }
    int cardCounter=0;
    foreach(KeyValuePair<char,int> amountOfCard in cardTypes)
    {
      if(amountOfCard.Value >cardCounter)
      {
        cardCounter= amountOfCard.Value;
      }
    }
    //five of a kind
    if(cardCounter == 5)
      return 7;
    //four of a kind
    if(cardCounter == 4)
      return 6;
    //single
    if(cardCounter == 1)
      return 1;
    //full fouse
    if(cardTypes.Count ==2)
      return 5;
    //three of a kind
    if(cardCounter == 3 && cardTypes.Count ==3)
      return 4;
    //pair
    if(cardCounter == 2 &&  cardTypes.Count ==4)
      return 2;
    
    //double pair
    return 3;
  }

}
