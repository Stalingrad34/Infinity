using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   public abstract class Enemy : MonoBehaviour
{
    public int helper;
    internal abstract void ApplyDamage(int damage);
    internal abstract void Shoot();    
}
