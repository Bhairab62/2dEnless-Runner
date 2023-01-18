using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public float DestroyingTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyingTime);
    }
}
