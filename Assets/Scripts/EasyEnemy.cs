﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EasyEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] private int health;
    [SerializeField] private int score;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private UnityEvent destroy;
    [SerializeField] private Animation boomAnimation;
    [SerializeField] private AudioSource boomSound;


    private void Start()
    {
        InvokeRepeating("Shoot", 2, 3);        
    }


    private void Update()
    {
        
    }

    public void ApplyDamage(int damage)
    {
        health -= damage*2;
        if (health <= 0)
        {
            destroy.Invoke();                    
            Destroy(gameObject, 2);
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
    }

}
