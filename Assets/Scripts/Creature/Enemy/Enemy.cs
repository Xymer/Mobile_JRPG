using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy : Creature
{
    public Enemy_SO enemyData;

    private void Start()
    {
        Initalize();
    }

    private void Initalize()
    {
        if (enemyData == null)
            throw new NullReferenceException();

        maxHitPoints = enemyData.maxHitPoints;
        currentHitPoints = enemyData.maxHitPoints;

        maxMagicPoints = enemyData.maxMagicPoints;
        currentMagicPoints = enemyData.maxMagicPoints;

        attack = enemyData.attack;
        defence = enemyData.defence;

        luck = enemyData.luck;
        agility = enemyData.agility;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
