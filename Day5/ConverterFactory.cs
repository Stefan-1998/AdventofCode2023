using System.Text.RegularExpressions;

namespace Day5{
    internal static class ConverterFactory{
        public static List<ConverterMap> CreateMaps(List<string> input)
        {
            ConverterMap map = new ConverterMap("Test");;
            var maps = new List<ConverterMap>();
            string convertName=String.Empty;
            foreach(var line in input)
            {
                if(line.Contains(':'))
                {
                    convertName=line.Split(':')[0];
                    map = new ConverterMap(convertName);
                    maps.Add(map);
                    continue;
                }
                if(String.IsNullOrEmpty(line))
                {
                    continue;
                }
                var numberRegex = new Regex(@"\d+");
                var matches = numberRegex.Matches(line);
                long destinationRangeStart = long.Parse(matches[0].Value);
                long sourceRangeStart = long.Parse(matches[1].Value);
                long range = long.Parse(matches[2].Value);

                map.AddRange(sourceRangeStart, destinationRangeStart, range);
            }
            return maps;

        }
    }
}