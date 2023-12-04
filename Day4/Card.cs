using System.Text.RegularExpressions;

namespace Day4{
    internal class Card{
        public Card(string cardSummarie)
        {
            WinningNumbers = GetWinningNumbers(cardSummarie);
            DrawnNumbers = GetDrawnNumbers(cardSummarie);
            Number = GetNumber(cardSummarie);
        }
        public List<int> WinningNumbers = new List<int>();
        public List<int> DrawnNumbers = new List<int>();
        public int Number;
        public int GetCardScore()
        {
            int numberOfPairs = GetNumberOfPairs();
            if(numberOfPairs==0)
                return 0;
            if(numberOfPairs==1)
                return 1;
            
            int cardScore = 1;
            for(int i=1; i< numberOfPairs; i++)
            {
                cardScore = 2*cardScore;
            }
            return cardScore;
        }
        public int GetNumberOfPairs()
        {
            int pairCounter = 0;
            foreach(var number in DrawnNumbers)
            {
                if(WinningNumbers.Contains(number))
                {
                pairCounter++;
                Console.Write($"{number} ");
                }
            }
            return pairCounter;
        }
        private int GetNumber(string inputLine)
        {
            var numberRegex = new Regex(@"\d+");
            return int.Parse(numberRegex.Match(inputLine).Value);
        }

        private List<int> GetWinningNumbers(string inputLine)
        {
        var winningNumbers = inputLine.Split(':')[1].Split('|')[0].Trim().Split(' ');
        return ParseNumbers(winningNumbers);
        }
        private List<int> GetDrawnNumbers(string inputLine)
        {
        var drawnNumbers = inputLine.Split(':')[1].Split('|')[1].Trim().Split(' ');
        return ParseNumbers(drawnNumbers);
        }
        private List<int> ParseNumbers(string[] numbers)
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
}