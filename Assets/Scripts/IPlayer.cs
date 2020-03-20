using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPlayer
{
    void Move(Vector2 direction);
    void ApplyDamage(int damage);
    void Shoot();
}