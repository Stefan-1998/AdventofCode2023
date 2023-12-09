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
    
    var inputNodes = input.Select(x => x.Split('=')[0].Trim()).ToList();
    var leftNodes = input.Select(x => x.Split('=')[1].Trim().Split(',')[0].Replace("(","").Trim()).ToList();
    var rightNodes = input.Select(x => x.Split('=')[1].Trim().Split(',')[1].Replace(")","").Trim()).ToList();
    
    foreach(var node in inputNodes)
    {
      Console.WriteLine(node);
    }
    int currentRelevantDirection = 0;
    var currentNodes = inputNodes.Where(x => x[2]=='A').ToList();
    var amountOfPaths = currentNodes.Count();

    var cyclesOfEachPath = new Dictionary<string, long>();
    long steps = 0;
    while(true)
    {
      if(currentNodes.Any(x => x[2]=='Z'))
      {
        string endNode = currentNodes.Where(x => x[2]=='Z').First();
        Console.WriteLine($"{endNode} Needed {steps} to get to the end");
        currentNodes.Remove(endNode);
        cyclesOfEachPath[endNode]=steps;
        if(amountOfPaths == cyclesOfEachPath.Keys.Count())
          break;
      }
      if(currentNodes.All(x => x[2]=='Z'))
      {
        Console.WriteLine($"Needed {steps} to get to ZZZ");
        break;
      }
      if(currentRelevantDirection >= directions.Count())
      {
        currentRelevantDirection=0;
      }
      var nodePositions = currentNodes.Select(node =>inputNodes.FindIndex(x => x==node)).ToList();
      if(directions[currentRelevantDirection]=='L')
      {
        currentNodes=nodePositions.Select(x => leftNodes[x]).ToList();
      }
      else
      {
        currentNodes=nodePositions.Select(x => rightNodes[x]).ToList();
      }
      if(steps>9999999)
        break;
      steps++;
      currentRelevantDirection++;
    }
    long result = 1;
    foreach(KeyValuePair<string,long> pair in cyclesOfEachPath)
    {
      result = lcm(result, pair.Value);
    }
    Console.WriteLine($"{result}");
  }
static long gcf(long a, long b)
{
    while (b != 0)
    {
        long temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

static long lcm(long a, long b)
{
    return (a / gcf(a, b)) * b;
}
}
