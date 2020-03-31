using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField] private Image barHP;
    [SerializeField] private Text scoreUI;
    [SerializeField] private Text coinsUI;
    [SerializeField] private Spawner spawner;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Transform spawnerPlayer;
    [SerializeField] private PlayerShip[] ships;
    public static float time;
    private IEnumerator createEnemy;
    private static int bestScore;
    internal static int score;
    private static int goldCoins;
    internal static Game currentGame;

    private void Awake()
    {
        if (currentGame == null)        
            currentGame = this;          
    }

    private void Start()
    {
        goldCoins = PlayerPrefs.GetInt("GoldCoins", 0);
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        currentGame.coinsUI.text = goldCoins.ToString();

        createEnemy = CreateEnemy();
        StartCoroutine(createEnemy);
        InvokeRepeating("CreateStar", 0, timeSpawnStar);

        Instantiate(ships[PlayerPrefs.GetInt("PlayerShip", 0)], spawnerPlayer.position, Quaternion.identity);
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
    }

    private void CreateStar()
    {
        spawner.SpawnStar();
        if (currentGame.barHP.fillAmount > 0)
            ChangeScore(1);          
    }

    private IEnumerator CreateEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSpawnEnemy);
            spawner.SpawnEnemy();          
        }            
    }

    internal static void CreateBonus(Vector2 positionBonus, int bonusChance)
    {
        var randomNumber = UnityEngine.Random.Range(0, 100);
        if (randomNumber < bonusChance)
        {
            currentGame.spawner.SpawnBonus(positionBonus);           
        }
    }

    internal static void ChangeBarHP(float hp) => currentGame.barHP.fillAmount = hp;
 
    internal static void ChangeScore(int inputScore)
    {
        score += inputScore;
        currentGame.scoreUI.text = score.ToString();
    }
    internal static void ChangeGoldCoin(int coin)
    {
        goldCoins += coin;
        currentGame.coinsUI.text = goldCoins.ToString();
    }

    internal static void GameOver()
    {
        if (score > bestScore)
            PlayerPrefs.SetInt("BestScore", score);

        PlayerPrefs.SetInt("GoldCoins", goldCoins);
        currentGame.gameOverPanel.SetActive(true);
    }
}
