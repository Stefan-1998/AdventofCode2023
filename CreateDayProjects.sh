#!/bin/bash

 
if [ $# -lt 1 ];
then
  echo "Daynumber needs to be set!"
  exit 1
fi

while [[ $# -gt 0 ]]; do
  case $1 in
    -d|--daynumber)
      DAY_NUMBER="$2"
      shift # past argument
      shift # past value
      ;;
    -*|--*)
      echo "Unknown option $1"
      exit 1
      ;;
  esac
done

echo $DAY_NUMBER
PROJECT_NAME="Day$DAY_NUMBER"
echo $PROJECT_NAME

echo "Creating console project with the name '$PROJECT_NAME'"
dotnet new console --name "$PROJECT_NAME"

echo "Add CommonFunctions reference"
dotnet add "./$PROJECT_NAME/$PROJECT_NAME.csproj" reference "./CommonFunctions/CommonFunctions.csproj"

echo "Add csproj to solution"
dotnet sln AdventOfCode2023.sln add "./$PROJECT_NAME/$PROJECT_NAME.csproj"

echo "Create InputFiles"
touch "./$PROJECT_NAME/Input.txt"
touch "./$PROJECT_NAME/ExampleInput.txt"

echo "Change Default Value of Program.cs"
cat > "./$PROJECT_NAME/Program.cs" << EOT
using CommonFunctions;
using System;

class Program{
  static void Main()
  {
    var input = InputReader.ReadInData(InputType.Example);
    foreach(var line in input)
    {
      Console.WriteLine(line);
    }
  }
}
EOT
 