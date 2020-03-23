using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Stars")]
    [SerializeField] private Star[] stars;

    [Tooltip("Time spawn star")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float timeSpawnStar;

    public void Start()
    {
        InvokeRepeating("SpawnStar", 0, timeSpawnStar);  
    }

    private void SpawnStar()
    {
        var starNumber = Random.Range(0, stars.Length);
        Vector2 starPosition = new Vector2(Random.Range(-3.0f, 3.0f), transform.position.y);
       
        stars[starNumber].Create(stars[starNumber], starPosition);
        
        
    }
}
