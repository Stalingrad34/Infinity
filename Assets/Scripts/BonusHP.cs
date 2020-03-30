using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHP : Bonus
{
    [SerializeField] private int giveHealth;  

    internal override void BonusEffect(GameObject player)
    {
        
        player.GetComponent<PlayerShip>().TakeBonusHP(giveHealth);
    }
}
