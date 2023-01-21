using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator an;
    public Text HeartText;

    public float Speed;
    private bool IsGround = true;
    public float MaxVelocity = 10f;
    public float MaxAcceleration = 10f;
    public float JumpForce = 10f;
    public float acceleration;
    //public float time;

    public int MaxHealth;
    public int CurrentHealth;
    public float DistanceToSpawn = 1f;
    private Vector2 vel;
    void Start()
    {
        CurrentHealth = MaxHealth;
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
            TakeDamage(1);
            rb.velocity = vel;
            transform.position = new Vector3(transform.position.x + DistanceToSpawn, 0f, 0f);
            vel = rb.velocity;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            TakeDamage(1);
            Debug.Log("Fire!!");
        }
        if (collision.tag == "arrow")
        {
            TakeDamage(1);
            an.SetTrigger("hit");
        }
    }
    void TakeDamage(int damage)
    {
        MaxHealth -= damage;
        CurrentHealth = MaxHealth;
        HeartText.text = MaxHealth.ToString();
        if (MaxHealth <= 0)
        {
            Die(.3f);
        }
    }
    void Die(float time)
    {
        Debug.Log("Player Has Zero Health!!");
        StartCoroutine(Wait(time));
    }
    IEnumerator Wait(float time)
    {
        GameObject.FindGameObjectWithTag("fl").GetComponent<Animator>().SetTrigger("flash");
        yield return new WaitForSeconds(time);
        Time.timeScale = 0f;
        Debug.Log("Setting time back or!!");
    }
}
