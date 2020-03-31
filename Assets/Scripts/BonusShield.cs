using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShield : Bonus
{
    [SerializeField] private int timeBonus;

    internal override void BonusEffect(GameObject player)
    {
        player.GetComponent<PlayerShip>().TakeBonusShield(timeBonus);
    }

}
