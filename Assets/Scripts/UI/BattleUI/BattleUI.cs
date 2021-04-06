using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    
    private PlayerCharacter player;
    private Enemy targetedEnemy;
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
        battleManager = FindObjectOfType<BattleManager>();
        player = FindObjectOfType<PlayerCharacter>();
        targetedEnemy = FindObjectOfType<Enemy>();

        attackButton.onClick.AddListener(delegate { player.Attack(targetedEnemy); });
        attackButton.onClick.AddListener(battleManager.AddTurn);
    }
    private void SetClickableButtons(BattleState battleState)
    {

    }
}
