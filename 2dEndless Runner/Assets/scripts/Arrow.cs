using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    public float speedArrow=10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.AddForce(new Vector2(-speedArrow * Time.deltaTime, 0f), ForceMode2D.Impulse);
        //transform.Translate(Vector2.left * speedArrow * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player Health Alert!!");
        }
    }
}
