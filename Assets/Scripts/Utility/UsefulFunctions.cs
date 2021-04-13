using System.Collections.Generic;
using UnityEngine;

public class UsefulFunctions
{
    /// <summary>
    /// Absolute banger of a function lads.
    /// <para>
    /// Uses the Random from Unity's standard library to get 0 or 1. 
    /// </para>
    /// <code>
    /// Random.Range(0, 2) == 0
    /// </code>
    /// </summary>
    /// <returns>true or false</returns>
    public static bool GetRandomBool()
    {
        return UnityEngine.Random.Range(0, 2) == 0;
    }

    /// <summary>
    /// A insertion sort function. <br/>
    /// Used for creating the start order, where the highest agility will be placed first in the list.
    /// </summary>
    /// <param name="list">The list that will be sorted.</param>
    public static void IntersertionSort(List<Creature> list)
    {
        for (int i = 1; i < list.Count; i++)
        {
            int j = i;

            while (j > 0)
            {
                if (list[j - 1].GetAgility() < list[j].GetAgility() ||
                    ((list[j - 1].GetAgility() == list[j].GetAgility()) && GetRandomBool()))
                {
                    Creature temp = list[j - 1];
                    list[j - 1] = list[j];
                    list[j] = temp;

                    j--;
                }

                else
                    break;
            }
        }
    }
}



