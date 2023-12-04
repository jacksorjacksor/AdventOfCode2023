var input = File.ReadAllLines("InputSample.txt").ToList();

var listOfPartNumbers = new List<PartNumberContainer>();

var listOfGearCoordinates = new List<Coordinates>();

// i = y axis - ROW
    for (var i = 0; i < input.Count; i++)
{
    var line = input[i];
    var partNumber = string.Empty;
    var listOfCoordinates = new List<Coordinates>();
    var adjacentSymbol = false;

    // j = x axis - COL
    for (var j = 0; j < line.Length; j++)
    {
        var character = line[j];
        if (char.IsDigit(character))
        {
            partNumber += character;
            listOfCoordinates.Add(new Coordinates(row: i, col: j));
            // Check adjacent
            // Console.WriteLine($"-CHECK-:x:{j}|y:{i}");
            if (adjacentSymbol == false)
            {
                adjacentSymbol = CheckAdjacent(input, j, i);
            }
            /*Console.WriteLine($"RESULT:{adjacentSymbol}");
            Console.WriteLine(" ");*/
        }
        else
        {
            if (partNumber != string.Empty)
            {
                listOfPartNumbers.Add(new PartNumberContainer(int.Parse(partNumber), adjacentSymbol, listOfCoordinates));
                partNumber = string.Empty;
                adjacentSymbol = false;
                listOfCoordinates = new List<Coordinates>();
            }
        }
    }

    if (partNumber != string.Empty)
    {
        listOfPartNumbers.Add(new PartNumberContainer(int.Parse(partNumber), adjacentSymbol, listOfCoordinates));
    }
}

// Calculate output
var output = 0;

foreach (var gearCoordinate in listOfGearCoordinates)
{
    var listOfAdjacentPartNumberContainers = new List<PartNumberContainer>();

    foreach (var partNumberContainer in listOfPartNumbers)
    {
        if (!partNumberContainer.IsPartNumber) { continue; }
        foreach (var coordinate in partNumberContainer.ListOfCoordinates)
        {
            // check proximity:
            if (IsAdjacent(gearCoordinate, coordinate))
            {
                if (!listOfAdjacentPartNumberContainers.Contains(partNumberContainer))
                {
                    listOfAdjacentPartNumberContainers.Add(partNumberContainer);
                }
            }
        }
    }
    // Calculate answer
    if (listOfAdjacentPartNumberContainers.Any())
    {
        int product = 1;
        foreach (var item in listOfAdjacentPartNumberContainers)
        {
            product *= item.PartNumber;
        }

        output += product;
    }
}

Console.WriteLine(output);

bool IsAdjacent(Coordinates coord1, Coordinates coord2) =>
    Math.Abs(coord1.Row - coord2.Row) <= 1 &&
    Math.Abs(coord1.Col - coord2.Col) <= 1;

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
            // Console.WriteLine($"charToCheck:{charToCheck}|row:{rowIndex}|col:{colIndex}");
            
            if(charToCheck.Equals('*'))
            {
                var newGear = new Coordinates(row: rowIndex, col: colIndex);

                var canAdd = true;
                foreach (var gearCoord in listOfGearCoordinates)
                {
                    if (gearCoord.GetId().Equals(newGear.GetId()))
                    {
                        canAdd = false;
                    }
                }

                if (canAdd)
                {
                    listOfGearCoordinates.Add(newGear);

                }

                return true;
            }
        }
    }
    return false;
}