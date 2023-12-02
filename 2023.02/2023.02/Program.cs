// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var input = File.ReadAllLines("InputMain.txt");
var output = 0;

foreach (var line in input)
{
    var DictOfCubesPerGame = new Dictionary<string, int>
    {
        { "red", 0 },
        { "green", 0 },
        { "blue", 0 },
    };


    var gameSplit = line.Split(":");
    var gameDetails = gameSplit[0];
    Console.WriteLine(gameDetails);
    var listOfSets = gameSplit[1].Split(";");
    foreach (var set in listOfSets)
    {
        var setTrim = set.Trim();
        var listOfCubes = setTrim.Split(",");
        foreach (var c in listOfCubes)
        {
            var cTrim = c.Trim();
            var colour = cTrim.Split(" ")[1];
            var amount = int.Parse(cTrim.Split(" ")[0]);

            if (amount > DictOfCubesPerGame[colour])
            {
                DictOfCubesPerGame[colour] = amount;
            }

        }
    }
    Console.WriteLine(line);

    var lineOutput = 0;



    foreach (var i in DictOfCubesPerGame)
    {
        if (i.Value > 0)
        {
            if (lineOutput == 0)
            {
                lineOutput = i.Value;
            }
            else
            {
                lineOutput *= i.Value;
            }
        }
        Console.WriteLine($"{i.Key}: {i.Value}");
    }
    Console.WriteLine(lineOutput);
    Console.WriteLine("++");
    output += lineOutput;
}

Console.WriteLine(output);