using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator an;

    public float Speed;
    private bool IsGround = true;

    public float JumpForce = 10f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        an = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            Jump();
            IsGround = false;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * Speed * Time.fixedDeltaTime);
    }
    void Jump()
    {
        an.SetTrigger("jump");
        rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            IsGround = true;
        }
    }
}
