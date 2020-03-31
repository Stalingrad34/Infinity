using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private PlayerShip[] ships;
    [SerializeField] private Image chooseShip;
    [SerializeField] private Image soundImageOn;
    [SerializeField] private Image startButton;
    [SerializeField] private Image buyButton;
    [SerializeField] private GameObject infoPriceUI;
    [SerializeField] private Text bestScore;
    [SerializeField] private Text goldCoins;
    [SerializeField] private Text priceUI;

    private int shipNumber;  
    private bool soundOff;
    private bool gameReady;
    private bool possibleBuy;

    private void Start()
    {
        chooseShip.sprite = ships[shipNumber].GetComponent<SpriteRenderer>().sprite;
        bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        goldCoins.text = PlayerPrefs.GetInt("GoldCoins", 0).ToString();
        CheckPurchase(ships[shipNumber]);
    }

    public void ChangeShipToLeft()
    {
        if (shipNumber > 0)       
            chooseShip.sprite = ships[--shipNumber].GetComponent<SpriteRenderer>().sprite;

        CheckPurchase(ships[shipNumber]);
    }

    public void ChangeShipToRight()
    {
        if (shipNumber < ships.Length-1)       
            chooseShip.sprite = ships[++shipNumber].GetComponent<SpriteRenderer>().sprite;

        CheckPurchase(ships[shipNumber]);

    }
    private void CheckPurchase(PlayerShip choosedShip)
    {
        var coins = PlayerPrefs.GetInt("GoldCoins", 0);

        if (choosedShip.isPurchased == false)
        {
            priceUI.text = choosedShip.price.ToString();
            infoPriceUI.gameObject.SetActive(true);
            gameReady = false;
            startButton.color = new Color(1, 0, 0);

            if (coins > choosedShip.price)
            {
                buyButton.color = new Color(0, 1, 0);
                possibleBuy = true;
            }
            else
            {
                buyButton.color = new Color(1, 0, 0);
                possibleBuy = false;
            }           
        }

        else
        {
            gameReady = true;
            infoPriceUI.gameObject.SetActive(false);
            startButton.color = new Color(1, 1, 1);
            buyButton.color = new Color(1, 1, 1);
        }
    }

    public void Sound()
    {
        if (!soundOff)
        {
            AudioListener.volume = 0;
            soundOff = true;
            soundImageOn.enabled = false;
        }
        else
        {
            AudioListener.volume = 1;
            soundOff = false;
            soundImageOn.enabled = true;
        }
    }

    public void Buy()
    {
        var coins = PlayerPrefs.GetInt("GoldCoins", 0);
        if (possibleBuy)
        {
            ships[shipNumber].isPurchased = true;
            coins -= ships[shipNumber].price;
            PlayerPrefs.SetInt("GoldCoins", coins);
            goldCoins.text = coins.ToString();
            CheckPurchase(ships[shipNumber]);
        }
    }

    public void StartGame()
    {
        if (gameReady)
        {
            Game.score = 0;
            Game.playerShip = ships[shipNumber];
            SceneManager.LoadScene("Game");
        }

    }

    //FF0008 красный
    //00FF1C зеленый
}
