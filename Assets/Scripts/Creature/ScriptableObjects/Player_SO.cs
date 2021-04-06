using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Creature/Player", order = 1)]
public class Player_SO : Creature_SO
{
    public JobClasses job = JobClasses.Warrior;
    public int maxLevel = 50;
}
