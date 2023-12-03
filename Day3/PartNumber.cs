namespace Day3
{
    internal class PartNumber{
        public PartNumber(int number, int line, int linePosition, int amountOfDigits)
        {
            Number = number;
            Line = line;
            LinePosition = linePosition;
            LinePositionEnd = linePosition+ amountOfDigits-1;
        }
        public int Number{get;init;}
        public int Line{get;init;}
        public int LinePosition{get;init;}
        public int LinePositionEnd{get;init;}
    
    
        public bool IsAdjacentToSpecialCharacter(List<(int Line,int Position)> specialCharacterPositions)
        {
            foreach(var specialCharacterPosition in specialCharacterPositions)
            {
            if(specialCharacterPosition.Line < Line-1 )
                continue;
            if(specialCharacterPosition.Line > Line+1 )
                continue;
            if(specialCharacterPosition.Position < LinePosition-1 )
                continue;
            if(specialCharacterPosition.Position > LinePositionEnd+1 )
                continue;
            return true;
            }
            Console.WriteLine($"The Partnumber {Number} is not valid!");
            return false;
        }
    }
}