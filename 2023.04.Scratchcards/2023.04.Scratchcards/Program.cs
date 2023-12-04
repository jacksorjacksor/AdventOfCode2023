// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

var input = File.ReadAllLines("InputMain.txt");

var output = 0;

foreach (var line in input)
{
    var nameOfCard = line.Split(":")[0];
    var winningNumbersAsStrings = line.Split(":")[1].Split("|")[0].Split(" ").ToList();
    var allNumbersAsStrings = line.Split(":")[1].Split("|")[1].Split(" ").ToList();

    winningNumbersAsStrings.RemoveAll(string.IsNullOrEmpty);
    allNumbersAsStrings.RemoveAll(string.IsNullOrEmpty);

    var winningNumbers = winningNumbersAsStrings.ConvertAll(int.Parse);
    var allNumbers = allNumbersAsStrings.ConvertAll(int.Parse);

    var lineOutput = 0;

    foreach (var number in winningNumbers)
    {
        if (allNumbers.Contains(number))
        {
            if (lineOutput == 0)
            {
                lineOutput = 1;

            }
            else
            {
                lineOutput *= 2;
            }
        }
    }
    Console.WriteLine($"{nameOfCard} : {lineOutput}");

    output += lineOutput;
}

Console.WriteLine(output);