using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, ICreature
{
    //public Creature_SO creatureData;

    protected int maxHitPoints = 0;
    protected int currentHitPoints = 0;

    protected int maxMagicPoints = 0;
    protected int currentMagicPoints = 0;

    protected int attack = 0;
    protected int defence = 0;

    protected int luck = 0;

    protected int agility = 0;

    protected bool killed = false;

    public int CalculateAttack(Creature otherCreature)
    {
        int totalDamage = attack * Mathf.RoundToInt((100f / (100f + otherCreature.defence)));
        Debug.Log("Damage: " + totalDamage);
        return totalDamage;
    }

    public int CalculateSpellAttack(Creature otherCreature)
    {
        throw new NotImplementedException();
    }

    public void SpellAttack()
    {
        throw new NotImplementedException();
    }

    public void Attack(Creature otherCreature)
    {
        int toAttack = CalculateAttack(otherCreature);

        otherCreature.TakeDamage(toAttack);

        //throw new NotImplementedException();
    }

    public void TakeDamage(int damageIn)
    {
        currentHitPoints -= damageIn;

        if (currentHitPoints <= 0)
            killed = true;
        Debug.Log("Current HP: " +currentHitPoints);
        //throw new NotImplementedException();
    }

}
