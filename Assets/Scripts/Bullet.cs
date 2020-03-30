using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private UnityEvent hit;
    [Tooltip("Damage")]
    [Range(0.0f, 100.0f)]
    [SerializeField] private int damage;  

    private void OnCollisionEnter2D(Collision2D target)
    {

        switch (target.gameObject.tag)
        {
            case "Player": 
                target.gameObject.GetComponent<PlayerShip>().ApplyDamage(damage);              
                break;
            case "Enemy":
                target.gameObject.GetComponent<Enemy>().ApplyDamage(damage);
                break;            
        }
        
            hit.Invoke();
            Destroy(gameObject,0.5f);	        
    }
}
