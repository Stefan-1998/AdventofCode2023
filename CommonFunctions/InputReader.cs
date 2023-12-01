using System;
using System.IO;
using System.Collections.Generic;
using CommonFunctions;

namespace CommonFunctions{

    public static class InputReader{
        public static IEnumerable<string> ReadInData(InputType inputType)
        {
            var inputPath = ResolveDataPath(inputType);
            if(!Path.Exists(inputPath)){throw new InvalidOperationException($"{inputPath} does not exists! The Execution needs to be in a Project Folder!");}
            return File.ReadLines(inputPath);
        }
        private static string ResolveDataPath(InputType inputType) => inputType switch 
        {
            InputType.Example => Path.GetFullPath(Path.Combine(Environment.CurrentDirectory,"ExampleInput.txt")),    
            InputType.Full => Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Input.txt")),
            _ => throw new InvalidOperationException($"{inputType} is unkown!")
        };
    }
}
