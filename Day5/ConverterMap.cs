
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
        public List<(long StartPoint, long Range )> ConvertRanges(long seedStartingPoint, long seedRange )
        {
            //first splitting up and then converting could help
            var convertedSections = new List<(long StartPoint, long Range)>();
            var notConvertedSections = new Queue<(long StartPoint, long Range)>();
            notConvertedSections.Enqueue((StartPoint: seedStartingPoint, Range: seedRange));
            foreach(var conversionRule in ConversionRules)
            {
                //cases no Conversion needed
                if(seedStartingPoint > conversionRule.SourceStartPoint+conversionRule.Range-1){continue;}
                if(seedStartingPoint+seedRange-1 < conversionRule.SourceStartPoint){continue;}

                //case converter on the left
                if(conversionRule.SourceStartPoint < seedStartingPoint && conversionRule.SourceStartPoint+conversionRule.Range-1 > seedStartingPoint)
                {
                    var offset= conversionRule.Range - (seedStartingPoint-conversionRule.SourceStartPoint);
                    convertedSections.Add((StartPoint: seedStartingPoint+conversionRule.DestinationStartPoint-conversionRule.SourceStartPoint, Range:offset));
                    seedStartingPoint = seedStartingPoint+ offset;
                    seedRange = seedRange - offset;
                    continue;
                }
                //case converter on the right
                if(conversionRule.SourceStartPoint < (seedStartingPoint+seedRange-1) && (conversionRule.SourceStartPoint+conversionRule.Range-1) >(seedStartingPoint+seedRange-1))
                {
                    var offset= seedStartingPoint + seedRange -conversionRule.SourceStartPoint;
                    convertedSections.Add((StartPoint: conversionRule.DestinationStartPoint, Range:offset));
                    seedRange = seedRange - offset;
                    continue;
                }
                //case converter in the middle
                if(conversionRule.SourceStartPoint > seedStartingPoint && (conversionRule.SourceStartPoint + conversionRule.Range-1) < seedStartingPoint + seedRange -1)
                {
                    convertedSections.Add((StartPoint: conversionRule.DestinationStartPoint, Range:conversionRule.Range));
                    continue;
                }
            }
            return convertedSections;
        }
    }
}