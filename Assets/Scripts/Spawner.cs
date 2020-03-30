using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{    
    [SerializeField] private Star[] stars;
    [Space]
    [SerializeField] private Enemy[] enemys; 
    [Space]
    [SerializeField] private Bonus[] bonuses;


    public void SpawnStar()
    {
        var starNumber = Random.Range(0, stars.Length);
        var spawnPosition = new Vector2(Random.Range(-3.0f, 3.0f), transform.position.y);
        stars[starNumber].Create(spawnPosition);              
    }

    public void SpawnEnemy()
    {
        var enemyNumber = Random.Range(0, enemys.Length);
        var spawnPosition = new Vector2(Random.Range(-2.3f, 2.3f), transform.position.y);
        Instantiate(enemys[enemyNumber], spawnPosition, Quaternion.identity);        
    }

    public void SpawnBonus(Vector2 spawnPositionBonus)
    {
        var bonusNumber = Random.Range(0, bonuses.Length);       
        Instantiate(bonuses[bonusNumber], spawnPositionBonus, Quaternion.identity);
    }
}
