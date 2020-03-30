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

    [SerializeField] private Image BarHP;
    [SerializeField] private Spawner spawner;
    [SerializeField] private PlayerShip playerShip;
    private float maxHP;
    private float time;
    private IEnumerator createEnemy;
    
    private void Start()
    {
        createEnemy = CreateEnemy();
        StartCoroutine(createEnemy);
        InvokeRepeating("CreateStar", 0, timeSpawnStar);       
        playerShip = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>();
        maxHP = playerShip.Health;        
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 10 && timeSpawnEnemy > 0)
        {
            StopCoroutine(createEnemy);
            time = 0;
            timeSpawnEnemy = timeSpawnEnemy / increaserTimeSpawnEnemy;
            StartCoroutine(createEnemy);                  
        }
       
        BarHP.fillAmount = (float)playerShip.Health / maxHP;

        if (playerShip.Health <= 0)
            Invoke("GameOver", 3);
        
    }

    private void CreateStar()
    {
        spawner.SpawnStar();
    }

    private IEnumerator CreateEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSpawnEnemy);
            spawner.SpawnEnemy();          
        }       
    }

    public void CreateBonus(Vector2 positionBonus, int bonusChance)
    {
        var randomNumber = Random.Range(0, 100);
        if (randomNumber < bonusChance)
        {
            spawner.SpawnBonus(positionBonus);
        }
    }

    public void GameOver()
    {
        
    }
}
