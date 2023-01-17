using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    public float Offsetx;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 TargetPos = new Vector3(player.position.x+Offsetx, transform.position.y, transform.position.z);
        transform.position = TargetPos;
    }
}
