using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    [Header("Size")]
    [SerializeField] private float minScale;
    [SerializeField] private float maxScale;
    [Header("Speed")]
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;


    public void Create(Vector2 starPosition)
    {
        Instantiate(this, starPosition, Quaternion.identity);

        GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];

        float randomScale = Random.Range(minScale, maxScale);  
        Vector3 starScale = new Vector3(randomScale, randomScale, randomScale);
        transform.localScale = starScale;

        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        GetComponent<MoveObject>().speed = randomSpeed;
       
    }
}
