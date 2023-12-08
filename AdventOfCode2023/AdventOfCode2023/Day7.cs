using System.Collections.Immutable;

namespace AdventOfCode2023;

public enum HandType
{
    FiveOfAKind,
    FourOfAKind,
    FullHouse,
    ThreeOfAKind,
    TwoPair,
    OnePair,
    HighCard
}

public class Day7
{
    public class CardHand: IComparable<CardHand>
    {
        private string _hand;
        public int _bid;
        public int? _rank;
        public HandType _type;
        
        public CardHand(string line)
        {
            var split = line.Split(" ");
            _hand = split[0];
            _bid = int.Parse(split[1]);
            if (_hand.Contains('J'))
            {
                if (_hand.Distinct().Count() == 1 || _hand.Count(c => c == 'J') == 4)
                {
                    _type = HandType.FiveOfAKind;
                }
                else if (_hand.Count(c => c == 'J') == 3)
                {
                    if (_hand.Distinct().Count() == 2)
                        _type = HandType.FiveOfAKind;
                    else if (_hand.Distinct().Count() == 3)
                        _type = HandType.FourOfAKind;
                }
                else if (_hand.Count(c => c == 'J') == 2)
                {
                    if (_hand.Distinct().Count() == 2)
                        _type = HandType.FiveOfAKind;
                    else if (_hand.Distinct().Count() == 3)
                        _type = HandType.FourOfAKind;
                    else
                    {
                        _type = HandType.ThreeOfAKind;
                    }
                }
                else if (_hand.Count(c => c == 'J') == 1)
                {
                    if (_hand.Distinct().Count() == 2)
                        _type = HandType.FiveOfAKind;
                    else if (_hand.Distinct().Count() == 3)
                    {
                        var letsGroup = _hand.GroupBy(c => c).Select(g=> g.Count());
                        _type = letsGroup.Any(g => g == 2) ? HandType.FullHouse : HandType.FourOfAKind;
                    }
                    else if (_hand.Distinct().Count() == 4)
                    {
                        _type = HandType.ThreeOfAKind;
                    }
                    else _type = HandType.OnePair;
                }
            }
            else if (_hand.Distinct().Count() == 1)
            {
                _type = HandType.FiveOfAKind;
            }
            else if (_hand.Distinct().Count() == 2)
            { 
                if (_hand.Count(c => c == _hand[0]) == 4 || _hand.Count(c => c == _hand[1]) == 4)
                {
                    _type = HandType.FourOfAKind;
                }
                else
                    _type = HandType.FullHouse;
                //4 of a kind or full house
            }
            else if (_hand.Distinct().Count() == 3)
            {
                var group = _hand.GroupBy(c => c).Select(g=> g.Count());
                if (group.Any(g => g == 3))
                {
                    _type = HandType.ThreeOfAKind;
                }
                else
                {
                    _type = HandType.TwoPair;
                }
                
            }
            else if (_hand.Distinct().Count() == 4)
            {
                _type = HandType.OnePair;
            }
            else
            {
                _type = HandType.HighCard;
            }
                
        }

        public int CompareTo(CardHand? that)
        {
            var newThis = this._hand.Replace('A', '>')
                .Replace('K','=' ).Replace('Q','<' )
                .Replace('J','0' ).Replace('T', ':');
            var newThat = that?._hand.Replace('A', '>')
                .Replace('K','=' ).Replace('Q','<' )
                .Replace('J','0' ).Replace('T', ':');
            for (int i = 0; i < newThis.Length; i++)
            {
                if (newThis[i] == newThat?[i])
                    continue;
                if (newThis[i] > newThat?[i])
                    return -1;
                return 1;
            }

            return 0;
        }
    }
    public static void Day7Part1()
    {
        var input = File.ReadAllLines(".\\TextFiles\\day7aoc.txt");
        var allHands = input.Select(line => new CardHand(line)).GroupBy(x => x._type).OrderBy(x => x.Key);

        var totalHands = input.Length;
        var total = 0;
        foreach (var handGrouping in allHands)
        {
            var sorted = handGrouping.ToList();
            sorted.Sort();
            foreach (var hand in sorted)
            {
                total += hand._bid * totalHands--;
            }
        }
        Console.WriteLine(total);
    }
    
    public static void Day7Part2()
    {
        var input = File.ReadAllLines(".\\TextFiles\\day7aoc.txt");
        var allHands = input.Select(line => new CardHand(line)).GroupBy(x => x._type).OrderBy(x => x.Key);

        var totalHands = input.Length;
        var total = 0;
        foreach (var handGrouping in allHands)
        {
            var sorted = handGrouping.ToList();
            sorted.Sort();
            foreach (var hand in sorted)
            {
                total += hand._bid * totalHands--;
            }
        }
        Console.WriteLine(total);
    }
}