using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerCharacter : Creature, IPlayer
{

    public Player_SO playerData;

    private AnimatorController.PlayerAnimatorController animatorController;

    private int currentLevel = 1;
    private int experiencePoints = 0;

    private int experiencePointsToNextLevel = 100;

    // Start is called before the first frame update
    void Awake()
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
        //TODO: Create callback for when experience to next level exceeds 0 and reduce next level experience points by the leftover

        if (experiencePointsToNextLevel <= 0 )
        {
            LevelUp();
        }
    }

    // ???? where do we do the kewl animation ddues
    //public override void Attack(Creature otherCreature)
    //{
    //    animatorController.SwitchState(AnimationParameters.Attack);
    //    base.Attack(otherCreature);
    //}


    public void EquipItem()
    {
        throw new NotImplementedException();
    }
    private void Initalize()
    {
        if (playerData == null)
            throw new NullReferenceException();

        animatorController = GetComponent<AnimatorController.PlayerAnimatorController>();
        if (animatorController == null)
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
