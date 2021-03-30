using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public interface ICreature 
{
    /// <summary>
    /// Calculate the damage what the attack will do
    /// </summary>
    /// <returns></returns>
    public  int CalculateAttack();
    /// <summary>
    /// Calculate the damage what the Spell/Skill will do
    /// </summary>
    /// <returns></returns>
    public int CalculateSpellAttack();
    public void SpellAttack();
    public void Attack();
    public int TakeDamage(int damageIn);
}

