using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BronzeShip : MonoBehaviour, IPlayer
{
    [Header("Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float timeForShoot;
    [SerializeField] private int health;
    [Space]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private UnityEvent destroy;
       

    public void Update()
    {
        Vector2 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(transform.position.x, -7, 2);
        currentPosition.y = Mathf.Clamp(transform.position.y, -4, 4);
        transform.position = currentPosition;

        timeForShoot += Time.deltaTime;
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }   

    public void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            destroy.Invoke();           
        }
    }

    public void Shoot()
    {
        if (timeForShoot > 1)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            timeForShoot = 0;
        }

    }
}
