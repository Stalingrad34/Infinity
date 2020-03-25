using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Stars")]
    [SerializeField] public Star[] stars;
    [Space]
    [SerializeField] public GameObject[] enemys;     

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
        enemys[enemyNumber].GetComponent<IEnemy>().Create(spawnPosition);
    }

    public void SpawnBonus(Vector2 spawnPositionBonus)
    {

    }
}
