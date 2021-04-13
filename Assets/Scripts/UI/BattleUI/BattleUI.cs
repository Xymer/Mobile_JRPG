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

    private List<Button> unclickableButtons = new List<Button>();

    private void Awake()
    {
        Initalize();
    }
    private void Update()
    {
       
    }
    private void Initalize()
    {
        battleManager = FindObjectOfType<BattleManager>();
        player = FindObjectOfType<PlayerCharacter>();
        targetedEnemy = FindObjectOfType<Enemy>(true);

        attackButton.onClick.AddListener(delegate { player.Attack(targetedEnemy);});
        attackButton.onClick.AddListener(targetedEnemy.TemporaryPassTurn);
        unclickableButtons.Add(attackButton);

        battleManager.OnChangeState += SetClickableButtons; //TODO: Seeing a bug with this later when we add multiple enemies
    }
    private void SetClickableButtons()
    {
        foreach (Button button in unclickableButtons)
        {
            button.enabled = !button.enabled;
        }
    }
}
