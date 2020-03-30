using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EdgeCollider2D))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]

public class PlayerShip : MonoBehaviour
{
    [Tooltip("Speed")]
    [Range(0.0f, 30.0f)]
    [SerializeField] private float speed;

    [Tooltip("Time between shoot")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float timeForShoot;

    [Tooltip("Health")]
    [Range(0, 1000)]
    [SerializeField] private int health;
    public int Health { get => health; }
    [Space]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private UnityEvent destroy;
    private Vector2 direction;
    private Rigidbody2D Rigidbody;
    private int maxHP;
    
    public void Start()
    {
        maxHP = health;
        Rigidbody = GetComponent<Rigidbody2D>();
        InvokeRepeating("Shoot", 0f, timeForShoot);    
    }

    public void Update()
    {
        Vector2 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(transform.position.x, -2.3f, 2.3f);
        currentPosition.y = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = currentPosition;
    }

    private void FixedUpdate()
    {      
        Rigidbody.velocity = direction * speed;
    }

    public void Move(Vector2 joystick)
    {      
            direction = joystick;            
    }   

    public void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)       
            destroy.Invoke();            
    }

    private void TakeBonusHP(int hp)
    {
        health += hp;
        if (health > maxHP)       
            health = maxHP;      
    }

    public void Shoot()
    {        
        Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();
    }

    public void OnCollisionEnter2D(Collision2D visitor)
    {
        switch (visitor.gameObject.tag)
        {
            case "Enemy":
                ApplyDamage(20);
                visitor.gameObject.GetComponent<Enemy>().ApplyDamage(1000);
                break;            
        }
    }
}
