using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameOffer
{
    public class CalculateMultiplePick
    {
        public static MultiplePickItem Calculate(long value, long itemsCount, int goodItemsCount)
        {
            MultiplePickItem returnValue = new MultiplePickItem();
            long lastItem = 0;
            string valueString = value.ToString();
            int minValueLength = valueString.Length - 4;
            if (minValueLength < 0)
                minValueLength = 0;
            long minValue = 1;
            for(int k = 0; k < minValueLength; k++)
            {
                minValue *= 10;
            }

            long maxItemVal = value / minValue;

            while(lastItem == 0)
            {
                returnValue.GoodItems = new List<long>();
                lastItem = maxItemVal;
                for(int i = 0; i < goodItemsCount - 1; i++)
                {
                    long newValue = (long) Math.Round( Random.Range( 0, lastItem));
                    returnValue.GoodItems.Add(newValue * minValue);
                    lastItem -= newValue;
                }
                returnValue.GoodItems.Add(lastItem * minValue);
            }
            returnValue.GoodItems.Sort((x, y) => y.CompareTo(x));
            
            long maxItem = returnValue.GoodItems[0] + minValue * 5;
            Debug.Log(goodItemsCount);
            long minItem = returnValue.GoodItems[goodItemsCount - 1] - minValue * 2;
            if(minItem < minValue)
            {
                minItem = minValue;
            }
            for(int i = goodItemsCount; i < itemsCount; i++ )
            {
                long newValue = (long) Math.Round( Random.Range( minItem, maxItem));
                returnValue.BadItems.Add(newValue);
            }

            return returnValue;
        }
    }

    public class MultiplePickItem
    {
        public List<long> GoodItems = new List<long>();
        public List<long> BadItems = new List<long>();
    }
}