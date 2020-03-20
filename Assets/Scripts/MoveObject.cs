using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] public float speed;
    [SerializeField] private Vector2 direction;
    [Header("Player Attack")]
    [SerializeField] private bool playerAttack;   
    [SerializeField] private float attackSpeed;
    [SerializeField] private Transform target;  
    

    void FixedUpdate()
    {
        if (playerAttack)  
            transform.position = Vector2.MoveTowards(transform.position, target.position, attackSpeed);
        else        
            transform.Translate(speed * direction.normalized);
        if (transform.position.x < -11 || transform.position.x > 11)
            Destroy(gameObject);
        
    }
}
