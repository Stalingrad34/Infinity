using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MoveObject))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animator))]

public class BonusHP : Bonus
{
    [SerializeField] private int giveHealth;
    public int GiveHealth {get => giveHealth;}

    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            Destroy(gameObject, 0.5f);
        }
    }

    internal override void TakeBonus()
    {

    }
}
