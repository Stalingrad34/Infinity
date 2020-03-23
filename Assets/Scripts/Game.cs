using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Image BarHP;
    public PlayerShip playerShip;
    private float maxHP; 
    
    void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>();
        maxHP = playerShip.Health;       
    }

    private void Update()
    {
        BarHP.fillAmount = (float)playerShip.Health / maxHP;
    }
   
}
