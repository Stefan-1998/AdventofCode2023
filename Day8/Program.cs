using CommonFunctions;
using System;

class Program{
  static void Main()
  {
    var input = InputReader.ReadInData(InputType.Full).ToList();
    foreach(var line in input)
    {
      Console.WriteLine(line);
    }
    var directions = input[0];
    input.RemoveAt(0);
    input.RemoveAt(0);

    string startNode = "AAA";

    
    var inputNodes = input.Select(x => x.Split('=')[0].Trim()).ToList();
    var leftNodes = input.Select(x => x.Split('=')[1].Trim().Split(',')[0].Replace("(","").Trim()).ToList();
    var rightNodes = input.Select(x => x.Split('=')[1].Trim().Split(',')[1].Replace(")","").Trim()).ToList();
    
    foreach(var node in inputNodes)
    {
      Console.WriteLine(node);
    }
    int currentRelevantDirection = 0;
    string currentNode = startNode;
    long steps = 0;
    while(true)
    {
      if(currentNode=="ZZZ")
      {
        Console.WriteLine($"Needed {steps} to get to ZZZ");
        break;
      }
      if(currentRelevantDirection >= directions.Count())
      {
        currentRelevantDirection=0;
      }
      int nodePosition = inputNodes.FindIndex(x => x==currentNode);
      if(directions[currentRelevantDirection]=='L')
      {
        currentNode=leftNodes[nodePosition];
      }
      else
      {
        currentNode=rightNodes[nodePosition];
      }
      if(steps>999999999)
        break;
      steps++;
      currentRelevantDirection++;
    }

  }
}
