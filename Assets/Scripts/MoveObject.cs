using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveObject : MonoBehaviour
{
    [Tooltip("Speed")]
    [Range(0.0f, 0.2f)]
    [SerializeField] public float speed;
    [SerializeField] private Vector2 direction;

    [Space]
    [SerializeField] internal bool playerAttack;
    [Tooltip("Attack Speed")]
    [Range(0.0f, 0.2f)]
    [SerializeField] private float attackSpeed;

    [SerializeField] internal Transform target;

    public void Start()
    {
        if (playerAttack)
        {
            target = GameObject.FindWithTag("Player").transform;
        } 
    }

    public void FixedUpdate()
    {
        if (playerAttack)  
            transform.position = Vector2.MoveTowards(transform.position, target.position, attackSpeed);
        else        
            transform.Translate(speed * direction.normalized);

        if (transform.position.y > 5.5f || transform.position.y < -5.5f)
            Destroy(gameObject);
        
    }
}
