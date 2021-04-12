using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private PlayerCharacter Player;
    private MonsterManager mm;

    public delegate void OnChangeStateDelegate();
    public event OnChangeStateDelegate OnChangeState;

    int currentTurn = 0;
    private BattleState currentState;

    private List<Enemy> EnemiesInCurrentBattle = new List<Enemy>();
    private List<Creature> BattleOrder = new List<Creature>();

    bool isBattleWon = false;
    public BattleState CurrentState
    {
        get { return currentState; }
        private set { currentState = value; }
    }

    private void OnEnable()
    {
    }
    private void Start()
    {
        mm = GetComponent<MonsterManager>();
        Player = FindObjectOfType<PlayerCharacter>();

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
            // End battle and do stuff
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

        CurrentState = (BattleOrder[0] == Player) ? BattleState.PlayerTurn : BattleState.EnemyTurn;

        Debug.Log($"Turn: {CurrentState}");
        //CurrentState = BattleState.PlayerTurn;
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
        else if (currentState == BattleState.PlayerTurn)
        {
            ChangeState(BattleState.EnemyTurn);
        }
        else if (currentState == BattleState.EnemyTurn)
        {
            ChangeState(BattleState.PlayerTurn);
        }
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

        EnemiesInCurrentBattle = mm.GetMonstersForBattle(1);

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
        BattleOrder.Clear();
        BattleOrder.TrimExcess();

        int currentAgility = 0;
        int playerAgility = Player.GetAgility();

        for (int i = 0; i < EnemiesInCurrentBattle.Count; i++)
        {
            currentAgility = EnemiesInCurrentBattle[i].GetAgility();
            Debug.Log($"Enemy: {currentAgility}, Player: {playerAgility}");

            if (playerAgility > currentAgility)
            {
                BattleOrder.Add(Player);
                BattleOrder.Add(EnemiesInCurrentBattle[i]);
            }
            else if (playerAgility < currentAgility)
            {
                BattleOrder.Add(EnemiesInCurrentBattle[i]);
                BattleOrder.Add(Player);
            }
            else
            {
                if (UsfulFunctions.GetRandomBool())
                {
                    BattleOrder.Add(Player);
                    BattleOrder.Add(EnemiesInCurrentBattle[i]);
                }
                else
                {
                    BattleOrder.Add(EnemiesInCurrentBattle[i]);
                    BattleOrder.Add(Player);
                }
            }
        }


    }


}
