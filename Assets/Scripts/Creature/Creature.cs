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

    public delegate void OnTakeDamageDelegate();
    public event OnTakeDamageDelegate OnTakeDamage;

    public delegate void OnDeathDelegate<Creature>();
    public event OnDeathDelegate<Creature> OnDeath;

    protected int maxHitPoints = 0;
    public int MaxHitPoints { get => maxHitPoints; private set => maxHitPoints = value; }

    public int CurrentHitPoints { get => currentHitPoints; private set => currentHitPoints = value; }
    protected int currentHitPoints = 0;

    private Creature targetedCreature = null;
    public Creature TargetedCreature { get => targetedCreature; set => targetedCreature = value; }

    protected int maxMagicPoints = 0;
    protected int currentMagicPoints = 0;

    protected int attack = 0;
    protected int defence = 0;

    protected int luck = 0;

    protected int agility = 0;

    protected bool killed = false;
    protected bool hasTakenTurn = false;
    public bool HasTakenturn { get => hasTakenTurn; set => hasTakenTurn = value; }

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

    public void Attack()
    {
        int toAttack = CalculateAttack(targetedCreature);

        targetedCreature.TakeDamage(toAttack);
        if (OnEndTurn != null)
        {
            OnEndTurn.Invoke();
        }
    }

    public void TakeDamage(int damageIn)
    {
        CurrentHitPoints -= damageIn;

        if (CurrentHitPoints <= 0)
        {
            if (OnDeath != null)
            {
                OnDeath.Invoke();
            }
            killed = true;
        }
        Debug.Log("Current HP: " + currentHitPoints);
        OnTakeDamage.Invoke();
    }

    public void StartTurn()
    {
        OnStartTurn.Invoke();

        // Just for testing, will change when enemy AI is in place
        if (this is Enemy)
        {
            SpellAttack();
        }
        if (OnStartTurn == null)
        {
            return;
        }
    }
    public void PlayAttackAnimation()
    {
        if (this is PlayerCharacter)
        {
            PlayerCharacter player = (PlayerCharacter)this;
            player.AnimatorController.SwitchState(AnimationParameters.Attack);
        }
    }
    protected void PlayIdleAnimation()
    {
        if (this is PlayerCharacter)
        {
            PlayerCharacter player = (PlayerCharacter)this;
            player.AnimatorController.SwitchState(AnimationParameters.Idle);
        }
    }
}
