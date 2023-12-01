// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var input = File.ReadAllLines("InputPart01.txt");

double outputValue = 0;
foreach (var line in input)
{
    Console.WriteLine(line);
    var startValue = GetCharacter(line);
    
    var endValue = GetCharacter(ReverseString(line));

    var finalValue = startValue + endValue;

    var thing = int.Parse(finalValue);
    outputValue += thing;
    Console.WriteLine(thing);
}

Console.WriteLine(outputValue);

string GetCharacter(string line)
{
    var output = string.Empty;

    foreach (var character in line.Where(char.IsDigit))
    {
        output = character.ToString();
        break;
    }
    return output;
}

// https://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
string ReverseString(string line)
{
    var arrayChar = line.ToCharArray();
    Array.Reverse(arrayChar);
    return new string(arrayChar);
}