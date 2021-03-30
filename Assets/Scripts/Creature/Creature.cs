using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, ICreature
{
    private int maxHitPoints = 10;
    private int currentHitPoints = 10;

    private int maxMagicPoints = 10;
    private int currentMagicPoints = 10;

    private int attack = 10;
    private int Luck = 10;

    private int maxLevel = 50;
    private int currentLevel = 1;

    public int CalculateAttack()
    {
        throw new NotImplementedException();
    }

    public int CalculateSpellAttack()
    {
        throw new NotImplementedException();
    }

    public void SpellAttack()
    {
        throw new NotImplementedException();
    }

    public void Attack()
    {
        throw new NotImplementedException();
    }

    public int TakeDamage(int damageIn)
    {
        throw new NotImplementedException();
    }
}
