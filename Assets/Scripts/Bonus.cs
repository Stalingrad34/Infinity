using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MoveObject))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animator))]

public abstract class Bonus : MonoBehaviour
{
    internal abstract void BonusEffect(GameObject player);

    internal virtual void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.tag == "Player")
        {           
            BonusEffect(player.gameObject);

            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            Destroy(gameObject, 0.5f);
        }
    }

}
