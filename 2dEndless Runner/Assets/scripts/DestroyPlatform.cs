using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public float DestroyingTime = 5f;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, DestroyingTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
    private void Update()
    {
       
    }
}
