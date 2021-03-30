using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum BattleState
{
    Start = 0,
    PlayerTurn,
    EnemyTurn,
    Win,
    Lose
}
public class BattleSystem : MonoBehaviour
{
    BattleState currentState;






    /// <summary>
    /// Start the battle and set if the player or Enemy should start
    /// </summary>
    /// <returns></returns>
    private void StartBattle(BattleState startingCharacterState)
    {
       //TODO: Implement StartBattle
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
}
