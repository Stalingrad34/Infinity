using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

   public abstract class Enemy : MonoBehaviour
{
    [Tooltip("Time between shoot")]
    [Range(0.0f, 1.0f)]
    [SerializeField] internal float timeForShoot;

    [Tooltip("Health")]
    [Range(0, 1000)]
    [SerializeField] internal int health;

    [Tooltip("Bonus chance")]
    [Range(0, 100)]
    [SerializeField] internal int bonusChance;

    [Tooltip("Score")]
    [Range(0, 3000)]
    [SerializeField] internal int score;
    [Space]
    [SerializeField] internal GameObject bulletPrefab;
    [SerializeField] internal Transform[] bulletSpawn;
    [SerializeField] internal UnityEvent destroy;

    public virtual void Start()
    {
        InvokeRepeating("Shoot", 1, timeForShoot);
    }

    internal virtual void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            destroy.Invoke();
            Game.ChangeScore(score);
            Game.CreateBonus(transform.position, bonusChance);
            Destroy(gameObject, 1.4f);
        }
    }

    internal virtual void Shoot()
    {
        foreach (var bullet in bulletSpawn)
        {
            Instantiate(bulletPrefab, bullet.position, Quaternion.identity);
        }       
    }    
}
