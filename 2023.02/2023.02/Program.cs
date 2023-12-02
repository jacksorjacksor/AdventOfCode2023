// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var input = File.ReadAllLines("InputMain.txt");
var DictOfCubes = new Dictionary<string, int>
{
    { "red", 12 },
    { "green", 13 },
    { "blue", 14 }
};
var listOfIds = new List<string>();
var listOfAllIds = new List<string>();

foreach (var line in input)
{
    var gameSplit = line.Split(":");
    var gameDetails = gameSplit[0];
    var gameNumber = gameDetails.Split(" ")[1].Trim();
    listOfAllIds.Add(gameNumber);
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
            // Console.WriteLine($"Colour:{colour}");
            // Console.WriteLine($"Amount:{amount}");
            if (DictOfCubes.ContainsKey(colour) && DictOfCubes[colour] >= amount)
            {
                // Console.WriteLine("Good!");
            }
            else
            {
                Console.WriteLine($"Impossible game: {gameDetails}");
                if (!listOfIds.Contains(gameNumber))
                {
                    listOfIds.Add(gameNumber);
                }
            }
        }
        Console.WriteLine(set);
    }
}

var allOutputs = 0;

foreach (var id in listOfAllIds)
{
    allOutputs += int.Parse(id);
}
Console.WriteLine($"All Outputs:{allOutputs}");
var output = 0;

foreach (var id in listOfIds)
{
    Console.WriteLine(id);
    output += int.Parse(id);
}

Console.WriteLine($"Negative Outputs:{output}");
Console.WriteLine(allOutputs-output);

