using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    
    private PlayerCharacter player;
    private BattleManager battleManager; 
    [SerializeField] private Button attackButton;
    [SerializeField] private Button skillButton;
    [SerializeField] private Button exitSkillListButton;
    [SerializeField] private Button fleeButton;
    [SerializeField] private Button[] skillButtons; 

    private void Awake()
    {
        Initalize();
    }
    private void Update()
    {
        if (battleManager.CurrentState == BattleState.EnemyTurn)
        {

        }
    }
    private void Initalize()
    {
        player = FindObjectOfType<PlayerCharacter>();
        battleManager = FindObjectOfType<BattleManager>();

        attackButton.onClick.AddListener(player.Attack);
        attackButton.onClick.AddListener(battleManager.AddTurn);
    }
    private void SetClickableButtons(BattleState battleState)
    {

    }
}
