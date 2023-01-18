using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerater : MonoBehaviour
{
    public GameObject[] Platform;

    public Transform LevelEndPoint;
    float LevelWidth;
    public float DistanceBetweenPoint;
    public int RandomPlatform;
    public Transform[] DifferentYpos;
    public float Length;
    private void Start()
    {
        
    }
    private void Update()
    {
        RandomPlatform = Random.Range(0, Platform.Length);
        LevelWidth = Platform[RandomPlatform].GetComponent<SpriteRenderer>().bounds.size.x;
        int RandomYPosition = Random.Range(0, DifferentYpos.Length);
        if (transform.position.x < LevelEndPoint.position.x)
        {
            Instantiate(Platform[RandomPlatform],new Vector3(transform.position.x +LevelWidth + DistanceBetweenPoint,DifferentYpos[RandomYPosition].position.y,0f) ,Quaternion.identity);
            transform.position += new Vector3(Length, 0f, 0f);
        }
    }
}
