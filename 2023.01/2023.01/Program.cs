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

    var answerArray = new Dictionary<int, string> { };

    foreach (var item in GetNumberNames())
    {
        // Find the index of the word in line
        answerArray.Add(line.IndexOf(item.Key), item.Value);
    }

    foreach (var character in line.Where(char.IsDigit))
    {
        output = character.ToString();
        answerArray.Add(line.IndexOf(output), output);
        break;
    }

    // Find the lowest index that is greater or equal to 0
    var lowestIndex = answerArray.Where(x => x.Key >= 0).Min(x => x.Key);

    return output;
}

Dictionary<string, string> GetNumberNames() => new()
{
    { "one", "1" },
    { "two", "2" },
    { "three", "3" },
    { "four", "4" },
    { "five", "5" },
    { "six", "6" },
    { "seven", "7" },
    { "eight", "8" },
    { "nine", "9" }
};

// https://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
string ReverseString(string line)
{
    var arrayChar = line.ToCharArray();
    Array.Reverse(arrayChar);
    return new string(arrayChar);
}