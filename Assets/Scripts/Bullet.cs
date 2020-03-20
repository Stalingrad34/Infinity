using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private UnityEvent hit;
    [SerializeField] private int damage;  

    void OnCollisionEnter2D(Collision2D target)
    {

        switch (target.gameObject.tag)
        {
            case "Player": 
                target.gameObject.GetComponent<IPlayer>().ApplyDamage(damage);
                break;
            case "Enemy":
                target.gameObject.GetComponent<IEnemy>().ApplyDamage(damage);
                break;            
        }
        
            hit.Invoke();
            Destroy(gameObject);	        
    }
}
