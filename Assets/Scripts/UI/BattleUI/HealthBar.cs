using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    const string HEALTH = "Health: ";
    Creature parent = null;
    public Creature Parent { get => parent; set => parent = value; }

    [SerializeField] Image mask = null;
    private Text healthBarText = null;

    float fillAmount = 0f;
    int lastCurrentHitpoints = 0;


    private void Awake()
    {
        enabled = false;
    }
    private void OnEnable()
    {
        lastCurrentHitpoints = parent.CurrentHitPoints;
        fillAmount = parent.CurrentHitPoints / parent.MaxHitPoints;
        mask.fillAmount = fillAmount;
        healthBarText = GetComponentInChildren<Text>();
        healthBarText.text = HEALTH + parent.CurrentHitPoints + '/' + parent.MaxHitPoints;
        parent.OnTakeDamage += UpdateHealthBar;
    }
   private void UpdateHealthBar()
    {
        lastCurrentHitpoints = parent.CurrentHitPoints;
        fillAmount = (float)parent.CurrentHitPoints / (float)parent.MaxHitPoints;
        mask.fillAmount = fillAmount;

        healthBarText.text = HEALTH + parent.CurrentHitPoints + '/' + parent.MaxHitPoints;
    }
}
