﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Mine : Enemy
{
    [SerializeField] private int health;    
    [SerializeField] private int score;
    [SerializeField] private float distanceToAttack;
    [SerializeField] private UnityEvent destroy;
    private Transform target;

    public void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    public void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance <= distanceToAttack)
            Shoot();                        
    }
    internal override void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GetComponent<MoveObject>().playerAttack = false;
            destroy.Invoke();           
            Destroy(gameObject, 1);
        }
    }

    internal override void Shoot()
    {
        if (health > 0)
        {
            GetComponent<MoveObject>().playerAttack = true;
            GetComponent<MoveObject>().target = target;
        }
    }

    public void CreateBonus()
    {
        throw new System.NotImplementedException();
    }
}
