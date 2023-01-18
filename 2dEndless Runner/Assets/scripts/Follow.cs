using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Player player;
    public float Speed;
    // Update is called once per frame
    void FixedUpdate()
    {
        Speed = player.transform.GetComponent<Rigidbody2D>().velocity.x;
        transform.Translate(Vector2.right*Speed* Time.fixedDeltaTime);
    }
}
