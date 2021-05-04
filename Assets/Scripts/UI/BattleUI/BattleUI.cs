using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{

    private PlayerCharacter player = null;
    private Enemy targetedEnemy = null;
    private BattleManager battleManager = null;
    private Camera mainCamera = null;
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
        mainCamera = FindObjectOfType<Camera>(true);

        attackButton.onClick.AddListener(delegate { player.TargetedCreature = targetedEnemy; player.PlayAttackAnimation(); });
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
        List<Creature> temp = battleManager.BattleOrder;
        //for (int i = 0; i < temp.Count; i++)
        //{

        //    GameObject GO = Instantiate(healthBar);
        //    HealthBar HPbar = GO.GetComponent<HealthBar>();
        //    HPbar.Parent = temp[i];
        //    HPbar.transform.position = mainCamera.WorldToScreenPoint(HPbar.Parent.transform.position) + new Vector3(0.0f, 200f);
        //    HPbar.enabled = true;
        //}
        foreach (Creature creature in temp)
        {
            if (creature is Enemy)
            {
                targetedEnemy = creature as Enemy;
            }
            GameObject GO = Instantiate(healthBar, healthBarParent.transform);
            HealthBar HPbar = GO.GetComponent<HealthBar>();
            HPbar.Parent = creature;
            HPbar.transform.position = mainCamera.WorldToScreenPoint(HPbar.Parent.transform.position) + new Vector3(0.0f, 200f);
            HPbar.enabled = true;
        }
    }
}
