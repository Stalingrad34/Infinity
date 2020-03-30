using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EasyEnemy : Enemy
{
    [Tooltip("Time between shoot")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float timeForShoot;

    [Tooltip("Health")]
    [Range(0, 1000)]
    [SerializeField] private int health;

    [Tooltip("Bonus chance")]
    [Range(0, 100)]
    [SerializeField] private int bonusChance;

    [SerializeField] private int score;
    [Space]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private UnityEvent destroy;

    public void Start()
    {
        InvokeRepeating("Shoot", 2, timeForShoot);     
        
    }

    internal override void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            destroy.Invoke();           
            FindObjectOfType<Game>().CreateBonus(transform.position, bonusChance);
            Destroy(gameObject, 1.4f);
        }
    }

    internal override void Shoot()
    {        
        Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
    }
 
}
