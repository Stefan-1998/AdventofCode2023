using CommonFunctions;
using Day2;

class Program{
  static void Main()
  {
    var input = InputReader.ReadInData(InputType.Full);

    const int maxAmountOfRedCubes = 12;
    const int maxAmountOfBlueCubes = 14;
    const int maxAmountOfGreenCubes = 13;

    int sumOfGameNumbers = 0;

    foreach(var line in input)
    {
      Console.WriteLine(line);
      var game = new Game(line);

      bool IsPossibleWithBlueCubes = !game.Sets.Any(t => t.NumberOfBlueCubes > maxAmountOfBlueCubes);
      bool IsPossibleWithGreenCubes = !game.Sets.Any(t => t.NumberOfGreenCubes > maxAmountOfGreenCubes);
      bool IsPossibleWithRedCubes = !game.Sets.Any(t => t.NumberOfRedCubes > maxAmountOfRedCubes);
      
      if(IsPossibleWithBlueCubes && IsPossibleWithGreenCubes && IsPossibleWithRedCubes)
      {
        sumOfGameNumbers += game.GameNumber;
        Console.WriteLine($"The game {game.GameNumber} is valid!");
      }
    }
    Console.WriteLine($"The sum of all the game numbers is {sumOfGameNumbers}");

    //puzzle 2

    int sumOfGamePowers = 0;
    foreach(var line in input)
    {
      Console.WriteLine(line);
      var game = new Game(line);

      int minimumAmountOfNeededBlueCubes = game.Sets.Max(t => t.NumberOfBlueCubes);
      int minimumAmountOfNeededRedCubes = game.Sets.Max(t => t.NumberOfRedCubes);
      int minimumAmountOfNeededGreenCubes = game.Sets.Max(t => t.NumberOfGreenCubes);
      
      int power = minimumAmountOfNeededBlueCubes * minimumAmountOfNeededGreenCubes * minimumAmountOfNeededRedCubes;
      
      sumOfGamePowers += power;
      Console.WriteLine($"The game {game.GameNumber} has the power {power}!");
      
    }
    Console.WriteLine($"The sum of all the game powers is {sumOfGamePowers}");
  }
}
