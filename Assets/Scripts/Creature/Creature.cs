using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, ICreature
{
    protected int maxHitPoints = 10;
    protected int currentHitPoints = 10;

    protected int maxMagicPoints = 10;
    protected int currentMagicPoints = 10;

    protected int attack = 10;
    protected int luck = 10;

    protected int maxLevel = 50;
    protected int currentLevel = 1;

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
