using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : Bonus
{
    [SerializeField] private int giveCoins;
    internal override void BonusEffect(GameObject player)
    {
        Game.ChangeGoldCoin(giveCoins);
    }
}
