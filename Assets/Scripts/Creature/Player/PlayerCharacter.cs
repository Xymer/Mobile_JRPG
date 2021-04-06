using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerCharacter : Creature, IPlayer
{

    public Player_SO playerData;
    private int currentLevel = 1;
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
        if (playerData == null)
            throw new NullReferenceException();

        maxHitPoints = playerData.maxHitPoints;
        currentHitPoints = playerData.maxHitPoints;

        maxMagicPoints = playerData.maxMagicPoints;
        currentMagicPoints = playerData.maxMagicPoints;

        attack = playerData.attack;
        defence = playerData.defence;

        luck = playerData.luck;
        agility = playerData.agility;

    }
}
