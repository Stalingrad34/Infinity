using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Mine : MonoBehaviour, IEnemy
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
        {
            GetComponent<MoveObject>().playerAttack = true;
            GetComponent<MoveObject>().target = target;
        }
    }
    public void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            destroy.Invoke();
            Destroy(gameObject, 1);
        }
    }

    public void Shoot()
    {
        
    }

}
