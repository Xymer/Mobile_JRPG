using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, ICreature
{
    //public Creature_SO creatureData;
    public delegate void OnEndTurnDelegate();
    public event OnEndTurnDelegate OnEndTurn;

    public delegate void OnStartTurnDelegate();
    public event OnStartTurnDelegate OnStartTurn;

    public delegate int OnTakeDamageDelegate();
    public event OnTakeDamageDelegate OnTakeDamage;

    protected int maxHitPoints = 0;
    public int MaxHitPoints { get => maxHitPoints; private set => maxHitPoints = value; }

    public int CurrentHitPoints { get => currentHitPoints; private set => currentHitPoints = value; }
    protected int currentHitPoints = 0;

    protected int maxMagicPoints = 0;
    protected int currentMagicPoints = 0;

    protected int attack = 0;
    protected int defence = 0;

    protected int luck = 0;

    protected int agility = 0;

    protected bool killed = false;


    public int GetAgility() { return agility; }

  
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
        OnEndTurn.Invoke();
    }

    public void Attack(Creature otherCreature)
    {
        int toAttack = CalculateAttack(otherCreature);

        otherCreature.TakeDamage(toAttack);

        OnEndTurn.Invoke();
        
    }

    public void TakeDamage(int damageIn)
    {
        currentHitPoints -= damageIn;

        if (currentHitPoints <= 0)
            killed = true;

  
        Debug.Log("Current HP: " + currentHitPoints);
    }

    public void StartTurn()
    {
        if (this is Enemy)
        {
            SpellAttack();           
        }
        if (OnStartTurn == null)
        {
            return;
        }
        OnStartTurn.Invoke();
    }
}
