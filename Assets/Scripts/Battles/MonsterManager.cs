using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject EnemySpawnPoint;
    public List<GameObject> enemies;

    void Start()
    {
        if(enemies.Count == 0)
        {
            throw new NullReferenceException();
        }

        if (EnemySpawnPoint == null)
            throw new NullReferenceException();
    }

    /// <summary>
    /// Get a set amount of enemies for the battle.<br/>
    /// Will be improved as time goes on. 
    /// </summary>
    /// <param name="SpawnAmount">How many enemies to spawn</param>
    /// <returns>The carefully selected monsters for the battle.</returns>
    public List<Enemy> GetMonstersForBattle(int SpawnAmount)
    {
        List<Enemy> EnemiesInBattle = new List<Enemy>();

        for (int i = 0; i < SpawnAmount; i++)
        {
            //We only have one monster atm :P
            GameObject go = Instantiate(enemies[0], EnemySpawnPoint.transform.position, EnemySpawnPoint.transform.rotation);
            Enemy e = go.GetComponent<Enemy>();
            EnemiesInBattle.Add(e);
        }

        return EnemiesInBattle;
    }
}
