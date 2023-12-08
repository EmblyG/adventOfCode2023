using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public class Day6
{
    public static void Day6Part1()
    {
        var input = File.ReadAllLines(".\\TextFiles\\day6aoc.txt");
        var times = Regex.Matches(input[0], "\\d+").Select(m => int.Parse(m.Value)).ToArray();
        var targetDistance = Regex.Matches(input[1], "\\d+").Select(m => int.Parse(m.Value)).ToArray();
        var finalAnswer = 1;
        for (var index = 0; index < times.Length; index++)
        {
            var winner = 0;
            for (var i = 1; i < times[index]; i++)
            {
                var boatLength = i * (times[index] - i);
                if (boatLength > targetDistance[index])
                {
                    winner++;
                }
            }

            finalAnswer *= winner;
        }
        Console.WriteLine(finalAnswer);
    }
    
    public static void Day6Part2()
    {
        long time = 46857582;
        var distance = 208141212571410;
        
        var finalAnswer = 0;
        {
            for (var i = 1; i < time; i++)
            {
                long boatLength = i * (time - i);
                if (boatLength > distance)
                {
                    finalAnswer++;
                }
            }
        }
        Console.WriteLine(finalAnswer);
    }
}