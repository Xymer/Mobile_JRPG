using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerCharacter : Creature, IPlayer
{
    private int experiencePoints = 0;

    private int experiencePointsToNextLevel = 100;

    // Start is called before the first frame update
    void Start()
    {
        Initalize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LevelUp()
    {
       //TODO: Implement level up and connect it to an excel sheet for levels
    }

    public void AddExperiencePoints(int pointsToAdd)
    {
        experiencePoints += pointsToAdd;
        experiencePointsToNextLevel -= pointsToAdd;
        if (experiencePointsToNextLevel <= 0 )
        {
            LevelUp();
        }
    }

    public void EquipItem()
    {
        throw new NotImplementedException();
    }
    private void Initalize()
    {
        maxHitPoints = 10;
        currentHitPoints = maxHitPoints;

        attack = 10;
        luck = 10;
        currentLevel = 1;
    }
}
