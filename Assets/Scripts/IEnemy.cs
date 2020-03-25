using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   public interface IEnemy
{
    void ApplyDamage(int damage);
    void Shoot();
    void Create(Vector2 enemyPosition);
    
}
