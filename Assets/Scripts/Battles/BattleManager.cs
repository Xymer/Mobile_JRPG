using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState
{
    Start = 0,
    PlayerTurn,
    EnemyTurn,
    Win,
    Lose
}

public class BattleManager : MonoBehaviour
{

    private PlayerCharacter player;
    public PlayerCharacter Player { get => player; private set => player = value; }
    private MonsterManager mm;

    public delegate void OnChangeStateDelegate();
    public event OnChangeStateDelegate OnChangeState;

    public delegate void OnAddTurnDelegate();
    public event OnAddTurnDelegate OnAddTurn;

    public delegate void OnCreateStartOrderDelegate();
    public event OnCreateStartOrderDelegate OnCreateStartOrder;

    int currentTurn = 0;
    private BattleState currentState;

    private List<Enemy> EnemiesInCurrentBattle = new List<Enemy>();
    private List<Creature> battleOrder = new List<Creature>();
    public List<Creature> BattleOrder { get => battleOrder; private set => battleOrder = value; }

    private Creature activeCreature = null;
    bool isBattleWon = false;
    public BattleState CurrentState
    {
        get { return currentState; }
        private set { currentState = value; }
    }



    // activeCreature == OnSwitchCreature Creature

    private void OnEnable()
    {
    }
    private void Start()
    {
        mm = GetComponent<MonsterManager>();
        player = FindObjectOfType<PlayerCharacter>();

        GetEnemiesForCurrentBattle();

        //The enemy and player needs to have spawned in and be initialized before this runs. Otherwise their stats will all be 0
        InitalizeBattle();

    }

    private void Update()
    {
        //Wait for input, Do attack , Deal damage, wait about 1 second then enemy decides what to do
        if (EnemiesInCurrentBattle.Count == 0 && !isBattleWon)
        {
            WinBattle();
        }
        else if (isBattleWon)
        {
            // Display Victory Scene
            // Do something more?
        }
    }
    /// <summary>
    /// Initalize the battle and set if the player or Enemy should start
    /// </summary>
    /// <returns></returns>
    private void InitalizeBattle()
    {
        currentTurn = 1;
        CreateStartOrder();

        CurrentState = (activeCreature == player) ? BattleState.PlayerTurn : BattleState.EnemyTurn;

        Debug.Log($"Turn: {CurrentState}");
    }
    /// <summary>
    /// Changes the state of the current battle
    /// </summary>
    private void ChangeState(BattleState nextState)
    {
        if (currentState == nextState)
        {
            return;
        }
        else
        {
            currentState = nextState;
            OnChangeState.Invoke();
        }

    }

    /// <summary>
    /// This happends when you win a battle
    /// </summary>
    private void WinBattle()
    {
        isBattleWon = true;
        ChangeState(BattleState.Win);
        //Safety so nothing lingers
        foreach (Creature creature in battleOrder)
        {
            creature.OnStartTurn -= AddTurn;
        }
    }
    /// <summary>
    /// This happends when you lose a battle
    /// </summary>
    private void LoseBattle()
    {
        //TODO: Implement Lose Condition
    }

    public void AddTurn()
    {
        currentTurn++;
        if (currentState == BattleState.Win || currentState == BattleState.Lose)
        {
            return;
        }

        activeCreature = SelectNextInBattleOrder();

        if (activeCreature == player)
        {
            ChangeState(BattleState.PlayerTurn);
        }
        else
        {
            ChangeState(BattleState.EnemyTurn);
            activeCreature.StartTurn();
        }
        //OnAddTurn.Invoke(); Vad skulle behöva lyssna på denna?
        Debug.Log("Turn: " + currentTurn);
    }

    /// <summary>
    /// Get enemies for the battle. Currently will just get a list of one :P<br/>
    /// A lil' setup for the future.
    /// </summary>
    private void GetEnemiesForCurrentBattle()
    {
        EnemiesInCurrentBattle.Clear();
        EnemiesInCurrentBattle.TrimExcess();

        EnemiesInCurrentBattle = mm.GetMonstersForBattle(2);

    }


    /// <summary>
    /// Absolute Shitstorm of a function right now. Still a work in progress.
    /// <para>
    /// Will calculate the turn order based on the agility stat of the enemies and player.<br/>
    /// Before every new battle the list will be fully reset.
    /// </para>
    /// </summary>
    private void CreateStartOrder()
    {
        //Remove all elements and trim capacity back to 0
        battleOrder.Clear();
        battleOrder.TrimExcess();


        foreach (Creature creature in EnemiesInCurrentBattle)
        {
            battleOrder.Add(creature);
            creature.OnDeath += RemoveCreatureOnDeath;
        }

        battleOrder.Add(player);
        UsefulFunctions.IntersertionSort(battleOrder);

        activeCreature = battleOrder[0];
        foreach (Creature creature in battleOrder)
        {
            creature.OnStartTurn += AddTurn;
            if (creature is Enemy)
            {
                Enemy enemy = (Enemy)creature;
            }
        }
        OnCreateStartOrder.Invoke();
    }

    private Creature GetNextInBattleOrder()
    {
        int nextCreatureIndex = battleOrder.IndexOf(activeCreature) + 1;
        if (nextCreatureIndex >= battleOrder.Count)
        {
            return battleOrder[0];
        }
        return battleOrder[nextCreatureIndex];
    }
    private Creature SelectNextInBattleOrder()
    {
        UsefulFunctions.IntersertionSort(battleOrder);
        for (int i = 0; i < battleOrder.Count; i++)
        {
            if (battleOrder[i].HasTakenturn)
            {
                continue;
            }
            else if (!battleOrder[i].HasTakenturn)
            {
                return battleOrder[i];
            }
            else
            {
                foreach (Creature creature in battleOrder)
                {
                    creature.HasTakenturn = false;
                }
                return SelectNextInBattleOrder();
            }            
        }
        throw new NullReferenceException($"No valid creatures in BattleOrder in BattleManager");
    }
    private void RemoveCreatureOnDeath()
    {
        Creature creatureToRemove = null;
        foreach (Creature creature in EnemiesInCurrentBattle)
        {
            if (creature.CurrentHitPoints <= 0)
            {
                creatureToRemove = creature;
                break;
            }
        }
        EnemiesInCurrentBattle.Remove(creatureToRemove as Enemy);
        creatureToRemove.OnStartTurn -= AddTurn;
        creatureToRemove.OnDeath -= RemoveCreatureOnDeath;

        Destroy(creatureToRemove.gameObject);
    }

    private void SetPlayerEnemyTarget(Button button)
    {
        player.TargetedCreature = button.GetComponentInParent<Enemy>();
    }
}
