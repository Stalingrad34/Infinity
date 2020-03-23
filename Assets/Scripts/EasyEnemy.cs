using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EasyEnemy : MonoBehaviour, IEnemy
{
    [Tooltip("Time between shoot")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float timeForShoot;

    [Tooltip("Health")]
    [Range(0, 1000)]
    [SerializeField] private int health;

    [SerializeField] private int score;
    [Space]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private UnityEvent destroy;

    public void Start()
    {
        InvokeRepeating("Shoot", 2, timeForShoot);     
        
    }

    public void ApplyDamage(int damage)
    {
        health -= damage*2;
        if (health <= 0)
        {
            destroy.Invoke();          
            Destroy(gameObject, 1);
        }
    }

    public void Shoot()
    {        
        Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
    }

}
