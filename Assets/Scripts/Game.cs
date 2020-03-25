using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Tooltip("Time spawn star")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float timeSpawnStar;

    [Tooltip("Time spawn enemy")]
    [Range(0.0f, 5.0f)]
    [SerializeField] private float timeSpawnEnemy;

    [Tooltip("Increaser spawn time")]
    [Range(1.0f, 3.0f)]
    [SerializeField] private float increaserTimeSpawnEnemy;

    [Tooltip("Bonus chance")]
    [Range(0, 100)]
    [SerializeField] private int bonusChance;

    [SerializeField] private Image BarHP;
    [SerializeField] Spawner spawner;
    public PlayerShip playerShip;
    private float maxHP;
    private float time;
    
    void Start()
    {
        StartCoroutine(CreateEnemy());
        InvokeRepeating("SpawnStar", 0, timeSpawnStar);
        playerShip = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>();
        maxHP = playerShip.Health;       
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 10 && timeSpawnEnemy > 0)
        {
            time = 0;
            timeSpawnEnemy = timeSpawnEnemy / increaserTimeSpawnEnemy;
            StartCoroutine(CreateEnemy());        
        }

        BarHP.fillAmount = (float)playerShip.Health / maxHP;
    }

    public void CreateStar()
    {
        spawner.SpawnStar();
    }

    IEnumerator CreateEnemy()
    {
        while (time < 10)
        {
            yield return new WaitForSeconds(timeSpawnEnemy);
            spawner.SpawnEnemy();
        }       
    }

    public void CreateBonus(Vector2 spawnPositionBonus)
    {
        var randomNumber = Random.Range(0, 100);

        if (randomNumber < bonusChance)
        {
            spawner.SpawnBonus(spawnPositionBonus);
        }
    }
    
}
