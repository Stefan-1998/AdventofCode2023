
namespace Day5{
    internal class ConverterMap{
        public ConverterMap(string name)
        {
            Name = name;
        }
        public void AddRange(long source, long destination, long range)
        {
            ConversionRules.Add((SourceStartPoint: source, DestinationStartPoint: destination, Range: range));
        }
        public List<(long SourceStartPoint, long DestinationStartPoint, long Range)> ConversionRules= new List<(long SourceStartPoint, long destinationStartPoint, long range)>();
        public string Name;
        public long Convert(long seed)
        {
            foreach(var conversionRule in ConversionRules)
            {
                if(seed < conversionRule.SourceStartPoint)
                    continue;
                if(seed > conversionRule.SourceStartPoint+conversionRule.Range-1)
                    continue;
                long offset = seed - conversionRule.SourceStartPoint;
                return conversionRule.DestinationStartPoint+offset;
            }
            return seed;
        }
    }
}