using CommonFunctions;
using System.Text.RegularExpressions;

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

  }
  public static readonly List<char> CardPossibilities = new List<char>(){'J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A' };
  public enum PokerHands
  {
    FiveOfAKind=7,
    FourOfAKind=6,
    FullHouse=5,
    ThreeOfAKind=4,
    TwoPairs = 3,
    OnePair =2,
    HighestCard =1
  }
  public static int SortByPokerRules((string Cards, int Bid) firstHand, (string Cards, int Bid) secondHand)
  {
    //return 0 => equal
    //return 1 => firstHand
    //return -1 => secondHand
    int firstHandType = (int)GetHandType(firstHand.Cards);
    int secondHandType = (int)GetHandType(secondHand.Cards);
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

  public static PokerHands GetHandType(string cards)
  {
    Dictionary<char,int> cardTypes = new Dictionary<char,int>();
    foreach(char card in cards)
    { 
      if(card == 'J')
        continue;
      if(cardTypes.ContainsKey(card))
      {
        cardTypes[card]++;
      }
      else{
        cardTypes[card]=1;
      }

    }
    int cardCounter= cardTypes.Values.Any() ? cardTypes.Values.Max():0;
    var jokerRegex = new Regex(@"J");
    var jokerAmount = jokerRegex.Matches(cards).Count;
    if(jokerRegex.IsMatch(cards))
    {
      return GetPokerHandWithJoker(jokerAmount, cardCounter, cardTypes.Count);
    }
    return GetPokerHandWithOutJoker(cardCounter, cardTypes.Count);
  }
  static private PokerHands GetPokerHandWithJoker(int amountOfJokers, int highestDuplicateOfACardType, int amountOfDifferentCardsInHand){
      return amountOfJokers switch 
      {
        //high card with joker
        4 => PokerHands.FiveOfAKind,
        3 when highestDuplicateOfACardType ==1 => PokerHands.FourOfAKind,
        2 when highestDuplicateOfACardType ==1 => PokerHands.ThreeOfAKind,
        1 when highestDuplicateOfACardType ==1 => PokerHands.OnePair,

        //one pair
        3 when highestDuplicateOfACardType ==2 => PokerHands.FiveOfAKind,
        2 when highestDuplicateOfACardType ==2 => PokerHands.FourOfAKind,
        1 when highestDuplicateOfACardType ==2 && amountOfDifferentCardsInHand == 3 => PokerHands.ThreeOfAKind,
        
        //two pair
        1 when highestDuplicateOfACardType ==2 && amountOfDifferentCardsInHand == 2 => PokerHands.FullHouse,

        //three of a kidn
        1 when highestDuplicateOfACardType ==3 => PokerHands.FourOfAKind,
        2 when highestDuplicateOfACardType ==3 => PokerHands.FiveOfAKind,

        //four of a kind
        1 when highestDuplicateOfACardType ==4 => PokerHands.FiveOfAKind,

        5 => PokerHands.FiveOfAKind,
        _ => throw new InvalidOperationException($"Unhandled case")
      };
  }
  static private PokerHands GetPokerHandWithOutJoker(int highestDuplicateOfACardType, int amountOfDifferentCardsInHand){

    return highestDuplicateOfACardType switch
    {
      5 => PokerHands.FiveOfAKind,
      4 => PokerHands.FourOfAKind,
      1 => PokerHands.HighestCard,
      3 when  amountOfDifferentCardsInHand ==2 => PokerHands.FullHouse,
      3 when  amountOfDifferentCardsInHand ==3 => PokerHands.ThreeOfAKind,
      2 when  amountOfDifferentCardsInHand ==4 => PokerHands.OnePair,
      _ => PokerHands.TwoPairs
    };
  }

}

