using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    
    private PlayerCharacter player;
    [SerializeField] private Button attackButton;
    [SerializeField] private Button skillButton;
    [SerializeField] private Button exitSkillListButton;
    [SerializeField] private Button fleeButton;
    [SerializeField] private Button[] skillButtons; 

    private void Awake()
    {
        Initalize();
    }

    private void Initalize()
    {
        player = FindObjectOfType<PlayerCharacter>();
        attackButton.onClick.AddListener(player.Attack);
    }
}
