using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    public float ParallaxEffect, ParallaxEffectY;
    private float StartPos, Length;
    private float Ypos;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position.x;
        Ypos = transform.position.y;
        Length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Distance = cam.transform.position.x * ParallaxEffect;
        float YDistance = cam.transform.position.y * ParallaxEffectY;
        transform.position = new Vector3(StartPos + Distance, Ypos+YDistance, transform.position.z);
        float temp = cam.transform.position.x * (1 - ParallaxEffect);

        if (temp > StartPos + Length)
        {
            StartPos += Length;
        }
    }
}
