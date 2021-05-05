using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Creature
{
    public Enemy_SO enemyData;

    private int expDrop = 0;
    private int goldDrop = 0;

    private EnemyAI EnemyAI;

    private Button selectionButton = null;

    public Button SelectionButton { get => selectionButton; private set => selectionButton = value; }

    private void OnEnable()
    {
        Initalize();
    }

    private void OnDisable()
    {
        
    }

    private void Initalize()
    {
        if (enemyData == null)
            throw new NullReferenceException();
        selectionButton = GetComponentInChildren<Button>();
        if (!selectionButton)
        {
            throw new NullReferenceException($"Selection Button is null in: {gameObject.name}");
        }
        //EnemyAI = GetComponent<EnemyAI>();

        //if (EnemyAI == null)
        //    throw new NullReferenceException();

        maxHitPoints = enemyData.maxHitPoints;
        currentHitPoints = enemyData.maxHitPoints;

        maxMagicPoints = enemyData.maxMagicPoints;
        currentMagicPoints = enemyData.maxMagicPoints;

        attack = enemyData.attack;
        defence = enemyData.defence;

        luck = enemyData.luck;
        agility = enemyData.agility;

        expDrop = enemyData.expDrop;
        goldDrop = enemyData.goldDrop;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Defeated()
    {

    }
    public void TemporaryPassTurn()
    {
        
    }

}
