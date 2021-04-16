using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{

    private PlayerCharacter player;
    private Enemy targetedEnemy;
    private BattleManager battleManager;
    [SerializeField] private Button attackButton = null;
    [SerializeField] private Button skillButton = null;
    [SerializeField] private Button exitSkillListButton = null;
    [SerializeField] private Button fleeButton = null;
    [SerializeField] private Button[] skillButtons = null;

    [SerializeField] private GameObject healthBar = null;
    [SerializeField] private GameObject healthBarParent = null;


    private List<Button> unclickableButtons = new List<Button>();

    private void Awake()
    {
        Initalize();
    }
    private void Start()
    {

    }
    private void Update()
    {

    }
    private void Initalize()
    {
        battleManager = FindObjectOfType<BattleManager>();
        player = FindObjectOfType<PlayerCharacter>();
        targetedEnemy = FindObjectOfType<Enemy>(true);


        attackButton.onClick.AddListener(delegate { player.Attack(targetedEnemy); });
        unclickableButtons.Add(attackButton);

        battleManager.OnChangeState += SetClickableButtons; //TODO: Seeing a bug with this later when we add multiple enemies
        battleManager.OnCreateStartOrder += GenerateHealthBar;
    }
    private void SetClickableButtons()
    {
        foreach (Button button in unclickableButtons)
        {
            button.enabled = !button.enabled;
        }
    }
    private void GenerateHealthBar()
    {
        foreach (Creature creature in battleManager.BattleOrder)
        {
            GameObject GO = Instantiate(healthBar);
            GO.transform.SetParent(healthBarParent.transform);
            HealthBar HPbar = GO.GetComponent<HealthBar>();
            HPbar.Parent = creature;

            HPbar.transform.position = FindObjectOfType<Camera>().WorldToScreenPoint(HPbar.Parent.transform.position) + new Vector3(0.0f,200f); 
            HPbar.enabled = true;
        }
    }
}
