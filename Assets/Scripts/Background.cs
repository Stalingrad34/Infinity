using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Material material;
    private Vector2 offset;
    
    void Start()
    {
       
        offset = material.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        offset.y += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
