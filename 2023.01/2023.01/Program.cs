var input = File.ReadAllLines("InputPart01.txt");

var outputValue = 0;
foreach (var line in input)
{
    Console.WriteLine(line);
    var startValue = GetCharacter(line);
    Console.WriteLine($"Start:{startValue}");
    var endValue = GetCharacterFromEnd(line);
    Console.WriteLine($"End:{endValue}");
    
    var finalValue = startValue + endValue;
    Console.WriteLine($"Final:{finalValue}");
    var finalValueAsInt = int.Parse(finalValue);
    outputValue += finalValueAsInt;

    Console.WriteLine("+++++");
}

Console.WriteLine(outputValue);

string GetCharacter(string line)
{
    var output = string.Empty;
    var index = line.Length;

    foreach (var item in GetNumberNames())
    {
        var foundIndex = line.IndexOf(item.Key, StringComparison.Ordinal);
        if (foundIndex >= 0 && foundIndex < index)
        {
            index=foundIndex;
            output = item.Value;
        }
    }

    for (var i = 0; i < line.Length; i++)
    {
        if (char.IsDigit(line[i]) && i >= 0 && i < index)
        {
            index = i;
            output = line[i].ToString();
        }
        
    }
    return output;
}

string GetCharacterFromEnd(string line) 
{
    for (var i = line.Length; i >= 0; i--)
    {
        var digitToCheck = line[i - 1];
        if (char.IsDigit(digitToCheck))
        {
            return line[i-1].ToString();
        }
        // Check if you can find a number
        foreach (var (numberKey, numberValue) in GetNumberNames())
        {
            if (i <= numberKey.Length) continue;
            var substringOfLine = line.Substring(i - numberKey.Length, numberKey.Length);
            
            if (numberKey.Equals(substringOfLine))
            {
                return numberValue;
            }
            
        }
    }

    return string.Empty;
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