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
    var expandedMap = ExpandMap(input);
    Console.WriteLine();
    Console.WriteLine();
    foreach(var line in expandedMap)
    {
      Console.WriteLine(line);
    }
    var galaxies = new List<(int XPosition, int YPosition)>();

    for(int i=0; i< expandedMap.Count(); i++)
    {
      for(int j=0; j< expandedMap[0].Count();j++)
      {
        if(expandedMap[i][j]=='#')
          galaxies.Add((XPosition: j, YPosition: i));
      }
    }
    Console.WriteLine(expandedMap.Count());
    Console.WriteLine(expandedMap[0].Count());
    
    long sumOfSteps = 0;
    for(int i=0; i<galaxies.Count();i++)
    {
      for(int j = i+1; j<galaxies.Count();j++)
      {
        sumOfSteps += Math.Abs(galaxies[i].XPosition-galaxies[j].XPosition);
        sumOfSteps += Math.Abs(galaxies[i].YPosition-galaxies[j].YPosition);
      }
    }

    Console.WriteLine($"The sum of the shortest paths between all the galaxies is {sumOfSteps}");

      

  }
  static List<string> ExpandMap(List<string> originalMap)
  {
    var horizontalPositionsToAdd = new List<int>();
    for(int i=0; i< originalMap.Count(); i++)
    {
      if(originalMap[i].Contains('#'))
        continue;
      
      horizontalPositionsToAdd.Add(i);
    }
    horizontalPositionsToAdd.Reverse();

    foreach(var lineNumber in horizontalPositionsToAdd)
    {
      originalMap.Insert(lineNumber, new string('.', originalMap[0].Count()));
    }
    var verticalPositionsToAdd = new List<int>();
    for(int j=0; j< originalMap[0].Count();j++)
    {
      bool containsHashTag = false;
      for(int i=0; i< originalMap.Count(); i++)
      {
        if(originalMap[i][j]=='#')
        {
          containsHashTag = true;
          break;
        }
      }
      if(containsHashTag==false)
      {
        verticalPositionsToAdd.Add(j);
      }
    }
    verticalPositionsToAdd.Reverse();


    foreach(var lineNumber in verticalPositionsToAdd)
    {
      for(int i=0; i< originalMap.Count(); i++)
      {
        string line = originalMap[i];
        originalMap[i] = line.Insert(lineNumber, "." );
      }
    }

    return originalMap;
  }
}
