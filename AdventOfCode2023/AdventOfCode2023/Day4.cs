using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public class Day4
{
    public static void Day4Part1()
    {
        var file = File.ReadAllLines(".\\TextFiles\\day4aoc.txt");
        double sum = 0;
        foreach (var line in file)
        {
            var card = line.Substring(8).Split("|");
            var winners = Regex.Matches(card[0], "\\d\\d?").Select(m => int.Parse(m.Value));
            var  elfNumbers= Regex.Matches(card[1], "\\d\\d?").Select(m => int.Parse(m.Value));
            var matches = elfNumbers.Count(number => winners.Contains(number));
            if (matches > 0)
                sum += Math.Pow(2,matches-1);
        }
        Console.WriteLine(sum);
    }
    
    public static void Day4Part2()
    {
        var file = File.ReadAllLines(".\\TextFiles\\day4aoc.txt");
        double sum = 0;
        var numberOfCards = Enumerable.Repeat(1, file.Length).ToList();
        for (var index = 0; index < file.Length; index++)
        {
            var line = file[index];
            var card = line.Substring(8).Split("|");
            var winners = Regex.Matches(card[0], "\\d\\d?").Select(m => int.Parse(m.Value));
            var elfNumbers = Regex.Matches(card[1], "\\d\\d?").Select(m => int.Parse(m.Value));
            var matches = elfNumbers.Count(number => winners.Contains(number));
            //this part needs to repeat for each card (original plus copies)
            sum += numberOfCards[index];
            for (var j = 0; j < numberOfCards[index]; j++)
            {
                for (var i = 1; i < matches + 1; i++)
                {
                    if (index + i < file.Length)
                    {
                        numberOfCards[index + i]++;
                    }

                }
            }
        }
        Console.WriteLine(sum);
    }
}