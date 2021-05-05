using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    MainMenu = 0,
    Battle,
    VictoryScene,
    SelectNextBattleScreen,
}
public class GameManager : MonoBehaviour
{
    PlayerCharacter playerCharacter = null;
    GameState currentState = GameState.MainMenu;

    public GameState CurrentState
    {
        get => currentState;

        private set
        {
            if (currentState != value)
            {
                currentState = value;
                OnChangeGameState?.Invoke();
            }
        }
    }

    private delegate void OnStartGameDelegate();
    private event OnStartGameDelegate OnStartGame;

    private delegate void OnChangeGameStateDelegate();
    private event OnChangeGameStateDelegate OnChangeGameState;



    private void Start()
    {
        //TODO: Get Saved player data.
        OnStartGame?.Invoke();
    }

    private void ChangeGameState(GameState nextState)
    {
        CurrentState = nextState;
    }
}
