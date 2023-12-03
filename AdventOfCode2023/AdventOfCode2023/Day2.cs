namespace AdventOfCode2023;

public class Day2
{
    public static void Day2Execute()
    {
        var file = File.ReadAllLines(".\\TextFiles\\day2aoc.txt");
        var sum = 0;
        for (var index = 0; index < file.Length; index++)
        {
            var red = 0;
            var green = 0;
            var blue = 0;
            var line = file[index].Split(';');
            foreach (var game in line)
            {
                var redIndex = game.IndexOf("red");
                if (redIndex > -1)
                {
                    var cubes = int.Parse(game.Substring((redIndex - 3), 2));
                    if (cubes > red)
                    {
                        red = cubes;
                    }
                       
                }
                var greenIndex = game.IndexOf("green");
                if (greenIndex > -1)
                {
                    var cubes = int.Parse(game.Substring((greenIndex - 3), 2));
                    if (cubes > green)
                    {
                        green = cubes;
                    }
                       
                }
                var blueIndex = game.IndexOf("blue");
                if (blueIndex > -1)
                {
                    var cubes = int.Parse(game.Substring((blueIndex - 3), 2));
                    if (cubes > blue)
                    {
                        blue = cubes;
                    }
                       
                }
            }

            sum += red * green * blue;
        }

        Console.WriteLine(sum);
    }
}