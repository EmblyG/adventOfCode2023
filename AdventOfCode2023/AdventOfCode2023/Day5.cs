using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public class Map
{
    public record CategoryMap(long destinationStartRange, long sourceRangeStart, long rangeLength);

    public List<CategoryMap> cats = new();

    public Map(string line)
    {
        var s = line.Replace(" map:", "").Trim().Split("-");
    }
        
    public void AddCategory(string line)
    {
        var s = line.Split(" ").Select(s=> s.Trim()).Where(s=>!string.IsNullOrEmpty(s)).ToList();
        cats.Add(new CategoryMap(long.Parse(s[0]),long.Parse(s[1]),long.Parse(s[2]) ));
    }
}

class Day5
{
    private List<Map> maps;
    private long[] seeds;

    public Day5()
    {
        var input = File.ReadAllLines(".\\TextFiles\\day5aoc.txt");
        seeds = Regex.Matches(input[0], "\\d+").Select(m => long.Parse(m.Value)).ToArray();
        maps = new();
        Map currentMap = null;

        var index = 0;
        foreach (var line in input)
        {
            if (index++ < 2) continue; // skip seeds and blank line
            if (line.Contains("map"))
            {
                currentMap = new Map(line);
                maps.Add(currentMap);
            }
            else
            {
                if (string.IsNullOrEmpty(line))
                {
                    // end of current map
                    currentMap = null;
                }
                else
                {
                    currentMap.AddCategory(line);
                }
            }
        }
    }

    public void Day5Part1()
    {
        var closest = long.MaxValue;
        foreach (var seed in seeds)
        {
            var location = TraverseTheMap(seed, 0);
            if (location < closest)
                closest = location;
        }
        Console.WriteLine(closest);
    }

    public long TraverseTheMap(long seed, int mapIndex)
    {
        foreach (var line in maps[mapIndex].cats)
        {
            if (seed >= line.sourceRangeStart && seed <= (line.sourceRangeStart + line.rangeLength))
            {
                seed = line.destinationStartRange + (seed - line.sourceRangeStart);
                if (mapIndex+1 < maps.Count)
                    TraverseTheMap(seed, mapIndex + 1);
                else
                {
                    return seed;
                }
            }
        }
        if (mapIndex+1 < maps.Count)
            TraverseTheMap(seed, mapIndex + 1);
        return seed;
    }
}

