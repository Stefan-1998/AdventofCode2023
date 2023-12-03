using System.Text.RegularExpressions;
using System;

namespace Day3{
    internal static class PartNumberFactory{
        public static List<PartNumber> CreatePartNumber(int lineNumber, string line) 
        {
            var numberRegex = new Regex(@"\d+");
            var matches = numberRegex.Matches(line);

            var partNumberList = new List<PartNumber>();
            foreach(Match match in matches)
            {
                partNumberList.Add(new PartNumber(int.Parse(match.Value),lineNumber,match.Index, match.Length));
            }
            return partNumberList;
        }
    }
}