using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public interface ICreature 
{
    /// <summary>
    /// Calculate the damage what the attack will do based on the attack stat of the user and the defence of the target
    /// </summary>
    /// <param name="otherCreature">The target</param>>
    /// <returns>The new damage</returns>
    public int CalculateAttack(Creature otherCreature);
    /// <summary>
    /// Calculate the damage what the Spell/Skill will do - TBA!!!
    /// </summary>
    /// <returns></returns>
    public int CalculateSpellAttack(Creature otherCreature);
    public void SpellAttack();

    /// <summary>
    /// Attack one selected target using a non magical attack. 
    /// </summary>
    /// <remarks>
    /// Uses CalculateAttack to get the final attack power.<br/>
    /// Check the <see cref="CalculateAttack(Creature)"/> summary for more information on the attack calulations.
    /// </remarks>
    /// <param name="otherCreature">The target</param>
    public void Attack();
    /// <summary>
    /// Removes as set amount of damage from the creatures current health.
    /// </summary>
    /// <param name="damageIn">How much damage the creature will take</param>
    public void TakeDamage(int damageIn);


}

