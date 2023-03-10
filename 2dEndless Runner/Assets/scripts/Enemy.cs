using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    Animator an;
    Transform player;

    public GameObject DeathEffect;
    public float DistanceBetween;
    public Transform ShootPoint;
    public GameObject arrow;
    public float StarTime;
    private float TimeBetweenShoot;
    private GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("CameraParent");
        TimeBetweenShoot = StarTime;
        rb = gameObject.GetComponent<Rigidbody2D>();
        an = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(rb.position, player.position) <= DistanceBetween)
        {
            if (TimeBetweenShoot <= 0f)
            {
                Instantiate(arrow, ShootPoint.position, ShootPoint.rotation);
                an.SetTrigger("shoot");
                TimeBetweenShoot = Time.time + StarTime;
            }
            else
            {
                TimeBetweenShoot -= Time.deltaTime;
            }
        }
    }

    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cam.gameObject.GetComponent<Animator>().SetTrigger("shake");
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
