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


    private delegate void OnChangeStateDelegate();
    private event OnChangeStateDelegate OnChangeState;
    
    int currentTurn = 0;
    private BattleState currentState;

    private List<Creature> BattleOrder;
    
    public BattleState CurrentState { 
        get { return currentState; }
        private set { currentState = value; }
    }

    private void OnEnable()
    {
        InitalizeBattle();
    }
    private void Start()
    {
     
    }
    
    private void Update()
    {
        //Wait for input, Do attack , Deal damage, wait about 1 second then enemy decides what to do
    }
    /// <summary>
    /// Initalize the battle and set if the player or Enemy should start
    /// </summary>
    /// <returns></returns>
    private void InitalizeBattle()
    {
        currentTurn = 1;
        CurrentState = BattleState.PlayerTurn;
    }
    /// <summary>
    /// Changes the state of the current battle
    /// </summary>
    private void ChangeState(BattleState nextState)
    {
        //TODO: Implement ChangeState
    }

    /// <summary>
    /// This happends when you win a battle
    /// </summary>
    private void WinBattle()
    {
        //TODO: Implement Win condition 
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
        Debug.Log("Turn: " + currentTurn);
    }


    private void CreateStartOrder()
    {

    }
}
