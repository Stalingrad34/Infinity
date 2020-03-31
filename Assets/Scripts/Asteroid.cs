using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Enemy
{
    public float speedRotation;
    public override void Start()
    {
            
    }
    private void Update()
    {
        if (transform.position.x > 4 || transform.position.x < -4)       
            Destroy(gameObject);       
    }
}
