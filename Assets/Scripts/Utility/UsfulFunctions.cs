using UnityEngine;

public class UsfulFunctions
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
        return Random.Range(0, 2) == 0;
    }

}
