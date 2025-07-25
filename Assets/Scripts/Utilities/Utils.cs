using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;

public class Utils
{
    public static NormalItem.eNormalType GetRandomNormalType()
    {
        Array values = Enum.GetValues(typeof(NormalItem.eNormalType));
        NormalItem.eNormalType result = (NormalItem.eNormalType)values.GetValue(URandom.Range(0, values.Length));

        return result;
    }

    public static NormalItem.eNormalType GetRandomNormalTypeExcept(NormalItem.eNormalType[] types)
    {
        List<NormalItem.eNormalType> list = Enum.GetValues(typeof(NormalItem.eNormalType)).Cast<NormalItem.eNormalType>().Except(types).ToList();

        int rnd = URandom.Range(0, list.Count);
        NormalItem.eNormalType result = list[rnd];

        return result;
    }

    public static NormalItem.eNormalType GetRandomNormalTypeExceptPriority(NormalItem.eNormalType[] types, List<NormalItem.eNormalType> listItemInLevel)
    {
        List<NormalItem.eNormalType> list = Enum.GetValues(typeof(NormalItem.eNormalType)).Cast<NormalItem.eNormalType>().Except(types).ToList();

        Dictionary<NormalItem.eNormalType, int> frequency = new Dictionary<NormalItem.eNormalType, int>();
        foreach (var type in list)
        {
            frequency[type] = listItemInLevel.Count(x => x == type);
        }
        int minCount = frequency.Values.Min();

        var leastUsed = frequency.Where(kv => kv.Value == minCount).Select(kv => kv.Key).ToList();

        int rnd = URandom.Range(0, leastUsed.Count);
        return leastUsed[rnd];
    }
}
