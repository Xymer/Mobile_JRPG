using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPlayer
{
    void LevelUp();
    void AddExperiencePoints(int pointsToAdd);
    void EquipItem();
}
