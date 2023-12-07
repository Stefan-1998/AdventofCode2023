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
  }
}
