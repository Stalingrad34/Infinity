using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Mine : Enemy
{
    [SerializeField] private float distanceToAttack;
    private Transform target;

    public override void Start()
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

}
