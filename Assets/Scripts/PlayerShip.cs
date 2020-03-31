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

    [Tooltip("Price")]
    [Range(0, 1000)]
    [SerializeField] internal int price;
    public int Health { get => health; }
    [Space]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private GameObject shield;
    [SerializeField] internal bool isPurchased;
    [SerializeField] private UnityEvent destroy;  
    private bool shieldOn;
    private Vector2 direction;
    private Rigidbody2D Rigidbody;
    private int maxHP;
    private IEnumerator shootRate;
    private IEnumerator stopBonus;
    
    private void Start()
    {
        maxHP = health;
        Rigidbody = GetComponent<Rigidbody2D>();
        shootRate = Shoot();
        StartCoroutine(shootRate);
    }

    private void Update()
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

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeForShoot);
            Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
        }      
    }

    internal void ApplyDamage(int damage)
    {
        if (!shieldOn)
        {
            health -= damage;
            Game.ChangeBarHP((float)health / (float)maxHP);
        }
        
        if (health <= 0)
        {
            StopCoroutine(shootRate);
            destroy.Invoke();
            Invoke("PlayerDead", 3);
        }       
    }

    internal void TakeBonusHP(int hp)
    {
        health += hp;
        if (health > maxHP)       
            health = maxHP;
        Game.ChangeBarHP((float)health / (float)maxHP);       
    }

    internal void TakeBonusShield(int timeBonus)
    {
        if (!shieldOn)
        {
            shield.SetActive(true);
            shieldOn = true;
            stopBonus = StopBonusShield(timeBonus);
            StartCoroutine(stopBonus);
        }    
    }

    private IEnumerator StopBonusShield(int timeBonus)
    {
        yield return new WaitForSeconds(timeBonus);
        shield.SetActive(false);
        shieldOn = false;
        stopBonus = null;
    }

    private void PlayerDead()
    {
        Game.GameOver();
        Time.timeScale = 0.0001f;
    }


    private void OnCollisionEnter2D(Collision2D visitor)
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
