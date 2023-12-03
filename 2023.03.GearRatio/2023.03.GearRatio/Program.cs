using System.Runtime.CompilerServices;

var input = File.ReadAllLines("InputFull.txt").ToList();

var readIntoMemory = "";

var listOfPartNumbers = new List<PartNumberContainer>();

var listOfAllCharactersUsed = new List<char>();

// i = y axis
    for (var i = 0; i < input.Count; i++)
{
    var line = input[i];
    var partNumber = string.Empty;
    var adjacentSymbol = false;

    // j = x axis
    for (var j = 0; j < line.Length; j++)
    {
        var character = line[j];
        if (char.IsDigit(character))
        {
            partNumber += character;
            // Check adjacent
            Console.WriteLine($"-CHECK-:x:{j}|y:{i}");
            if (adjacentSymbol == false)
            {
                adjacentSymbol = CheckAdjacent(input, j, i);
            }
            Console.WriteLine($"RESULT:{adjacentSymbol}");
            Console.WriteLine(" ");
        }
        else
        {
            if (partNumber != string.Empty)
            {
                listOfPartNumbers.Add(new PartNumberContainer(int.Parse(partNumber), adjacentSymbol));
                partNumber = string.Empty;
                adjacentSymbol = false;
            }
        }
    }

    if (partNumber != string.Empty)
    {
        listOfPartNumbers.Add(new PartNumberContainer(int.Parse(partNumber), adjacentSymbol));
    }
}

var output = 0;
foreach (var thing in listOfPartNumbers)
{
    Console.WriteLine(thing.PartNumber);
    Console.WriteLine(thing.IsPartNumber);
    Console.Write(" ++");
    if (thing.IsPartNumber)
    {
        output += thing.PartNumber;
    }
}
Console.WriteLine(output);

bool CheckAdjacent(List<string> listOfThings, int y, int x)
{
    var maxWidth = listOfThings[0].Length;
    var maxHeight = listOfThings.Count;

    Console.WriteLine("---");

    // i = y axis
    for (var rowIndex = x - 1; rowIndex <= x + 1; rowIndex++)
    {
        if (rowIndex < 0 || rowIndex >= maxHeight) {continue;}
        var lineToCheck = listOfThings[rowIndex];
        // j = x axis
        for (var colIndex = y - 1; colIndex <= y + 1; colIndex++)
        {
            if (colIndex < 0 || colIndex >= maxHeight) { continue; }
            if(rowIndex.Equals(x) && colIndex.Equals(y)) {continue;}

            var charToCheck = lineToCheck[colIndex];
            Console.WriteLine($"charToCheck:{charToCheck}|row:{rowIndex}|col:{colIndex}");
            
            if(!char.IsDigit(charToCheck) && !charToCheck.Equals('.'))
            {
                Console.WriteLine("Huzzah!");
                return true;
            }
            else
            {
                Console.WriteLine("Nope");
            }
            

        }
    }
    return false;
}


/*public class Coordinates
{
    public int Row {get; set; }
    public int Col { get; set; }
    public Coordinates(int row, int col)
    {
        Row = row;
        Col = col;
    }
}*/


public class PartNumberContainer
{
    public int PartNumber { get; set; }
    public bool IsPartNumber { get; set; }

    public PartNumberContainer(int partNumber, bool isPartNumber)
    {
        this.PartNumber = partNumber;
        this.IsPartNumber = isPartNumber;
    }
}