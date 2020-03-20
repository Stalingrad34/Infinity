using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Stars")]
    [SerializeField] private Star[] stars;
    [SerializeField] private float timeStarSpawn;

    public void Start()
    {
        InvokeRepeating("SpawnStar", 0, timeStarSpawn);  
    }

    private void SpawnStar()
    {
        var starNumber = Random.Range(0, stars.Length);
        Vector2 starPosition = new Vector2(transform.position.x, Random.Range(-6.0f, 6.0f));
       
        stars[starNumber].Create(stars[starNumber], starPosition);
        
        
    }
}
