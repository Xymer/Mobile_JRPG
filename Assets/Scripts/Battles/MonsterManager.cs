using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public List<GameObject> enemies;

    void Start()
    {
        if(enemies.Count == 0)
        {
            throw new NullReferenceException();
        }
    }

    public List<GameObject> GetMonstersForBattle(int MonstersToSpawn)
    {
        List<GameObject> enemiesToSpawn = new List<GameObject>();


        return enemiesToSpawn;
    }

}
