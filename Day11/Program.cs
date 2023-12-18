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
    var verticalSpaceExpansions = GetVerticalSpaceExpensions(input);
    var horizontalSpaceExpensions = GetHorizontalSpaceExpensions(input);

    var galaxies = new List<(int XPosition, int YPosition)>();

    for(int i=0; i< input.Count(); i++)
    {
      for(int j=0; j< input[0].Count();j++)
      {
        if(input[i][j]=='#')
          galaxies.Add((XPosition: j, YPosition: i));
      }
    }
    
    long expensionRate = 1000000;
    long sumOfSteps = 0;
    for(int i=0; i<galaxies.Count();i++)
    {
      for(int j = i+1; j<galaxies.Count();j++)
      {
        int amountOfVerticalSpace = 0;
        if(galaxies[j].XPosition > galaxies[i].XPosition)
          amountOfVerticalSpace = verticalSpaceExpansions.Where(t => galaxies[i].XPosition <t && t <galaxies[j].XPosition).Count();
        else
        {
          amountOfVerticalSpace = verticalSpaceExpansions.Where(t => galaxies[j].XPosition <t && t <galaxies[i].XPosition).Count();
        }
        int amountOfHorizonalSpace = 0;
        if(galaxies[j].YPosition > galaxies[i].YPosition)
          amountOfHorizonalSpace = horizontalSpaceExpensions.Where(t => galaxies[i].YPosition <t && t <galaxies[j].YPosition).Count();
        else
        {
          amountOfHorizonalSpace = horizontalSpaceExpensions.Where(t => galaxies[j].YPosition <t && t <galaxies[i].YPosition).Count();
        }
        
        sumOfSteps += Math.Abs(galaxies[i].XPosition-galaxies[j].XPosition)+amountOfHorizonalSpace*(expensionRate-1);
        sumOfSteps += Math.Abs(galaxies[i].YPosition-galaxies[j].YPosition)+amountOfVerticalSpace*(expensionRate-1);
      }
    }

    Console.WriteLine($"The sum of the shortest paths between all the galaxies is {sumOfSteps}");

      

  }
  static List<int> GetHorizontalSpaceExpensions(List<string> originalMap)
  {
    var horizontalSpaceExpensions = new List<int>();
    for(int i=0; i< originalMap.Count(); i++)
    {
      if(originalMap[i].Contains('#'))
        continue;
      
      horizontalSpaceExpensions.Add(i);
    }
    return horizontalSpaceExpensions;
  }
  static List<int> GetVerticalSpaceExpensions(List<string> originalMap)
  {
    var verticalSpaceExpansions = new List<int>();
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
        verticalSpaceExpansions.Add(j);
      }
    }
    return verticalSpaceExpansions;
  }
}
