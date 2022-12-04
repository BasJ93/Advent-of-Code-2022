using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Interfaces;

namespace AdventOfCode2022.Solutions;

public class Day3 : ISolution
{
    private readonly Dictionary<char, int> _itemTypeValues = new()
    {
        { 'a', 1 }, { 'A', 27 },
        { 'b', 2 }, { 'B', 28 },
        { 'c', 3 }, { 'C', 29 },
        { 'd', 4 }, { 'D', 30 },
        { 'e', 5 }, { 'E', 31 },
        { 'f', 6 }, { 'F', 32 },
        { 'g', 7 }, { 'G', 33 },
        { 'h', 8 }, { 'H', 34 },
        { 'i', 9 }, { 'I', 35 },
        { 'j', 10 }, { 'J', 36 },
        { 'k', 11 }, { 'K', 37 },
        { 'l', 12 }, { 'L', 38 },
        { 'm', 13 }, { 'M', 39 },
        { 'n', 14 }, { 'N', 40 },
        { 'o', 15 }, { 'O', 41 },
        { 'p', 16 }, { 'P', 42 },
        { 'q', 17 }, { 'Q', 43 },
        { 'r', 18 }, { 'R', 44 },
        { 's', 19 }, { 'S', 45 },
        { 't', 20 }, { 'T', 46 },
        { 'u', 21 }, { 'U', 47 },
        { 'v', 22 }, { 'V', 48 },
        { 'w', 23 }, { 'W', 49 },
        { 'x', 24 }, { 'X', 50 },
        { 'y', 25 }, { 'Y', 51 },
        { 'z', 26 }, { 'Z', 52 },
    };

    public async Task<long> Task1(IEnumerable<string> input, CancellationToken ctx)
    {
        long totalPriority = 0;
        List<char> doubleItemTypes = new List<char>();

        foreach (string s in input)
        {
            int numberOfItems = s.Length;

            int halfWayIndex = numberOfItems / 2;
            
            string firstCompartment = s[..halfWayIndex];
            string secondCompartment = s[halfWayIndex..];

            List<char> sharedItemType = firstCompartment.Intersect(secondCompartment).ToList();

            if (sharedItemType.Count == 1)
            {
                doubleItemTypes.AddRange(sharedItemType);
            }
        }

        foreach (char itemType in doubleItemTypes)
        {
            totalPriority += _itemTypeValues[itemType];
        }

        return totalPriority;
    }

    public async Task<long> Task2(IEnumerable<string> input, CancellationToken ctx)
    {
        List<string> inputAsList = input.ToList();
        
        long totalPriority = 0;
        List<char> groupItemType = new List<char>();

        for (int i = 0; i < inputAsList.Count; i += 3)
        {
            List<string> elveGroup = inputAsList.Skip(i).Take(3).ToList();

            if (elveGroup.Count != 3) continue;
            
            List<char> doubleTypes = elveGroup[0].Intersect(elveGroup[1]).ToList();

            List<char> sharedTypes = elveGroup[2].Intersect(doubleTypes).ToList();

            if (sharedTypes.Count == 1)
            {
                groupItemType.AddRange(sharedTypes);
            }
        }
        
        foreach (char itemType in groupItemType)
        {
            totalPriority += _itemTypeValues[itemType];
        }

        return totalPriority;
    }
}