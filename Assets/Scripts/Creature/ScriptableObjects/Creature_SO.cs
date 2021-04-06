using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_SO : ScriptableObject
{
    public int maxHitPoints = 20;
    public int currentHitPoints = 20;

    public int maxMagicPoints = 10;
    public int currentMagicPoints = 10;

    public int attack = 10;
    public int defence = 10;

    public int luck = 10;

    public int agility = 10;
}
