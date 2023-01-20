using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator an;

    public float Speed;
    private bool IsGround = true;
    public float MaxVelocity = 10f;
    public float MaxAcceleration = 10f;
    public float JumpForce = 10f;
    public float acceleration;
    //public float time;

    public float DistanceToSpawn = 1f;
    private Vector2 vel;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        an = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Pintu");
        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            Jump();
            IsGround = false;
        }
    }

    void FixedUpdate()
    {
        vel = rb.velocity;
        float VelocityRatio = rb.velocity.x /MaxVelocity;
        acceleration = MaxAcceleration * (1 - VelocityRatio);
        vel.x += acceleration*Time.fixedDeltaTime;
        if (vel.x >= MaxVelocity)
        {
            vel.x = MaxVelocity;
        }
        an.speed+=.01f*Time.fixedDeltaTime;
        rb.velocity = vel;
    }
    void Jump()
    {
        int RandomAnimation = Random.Range(0, 2);
        if (RandomAnimation == 0)
        {
            an.SetTrigger("roll");
        }
        else if (RandomAnimation==1)
        {
            an.SetTrigger("jump");
        }
        rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            IsGround = true;
        }
        if (collision.collider.tag == "point")
        {
            Debug.Log("Restart the Game!!");
            rb.velocity = vel;
            transform.position = new Vector3(transform.position.x + DistanceToSpawn, 0f, 0f);
            vel = rb.velocity;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            an.SetTrigger("hit");
            Debug.Log("Fire!!");
        }
        if (collision.tag == "arrow")
        {
            an.SetTrigger("hit");
        }
    }
}
