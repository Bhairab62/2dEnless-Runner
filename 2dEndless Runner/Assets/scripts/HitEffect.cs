using UnityEngine;
public class HitEffect : MonoBehaviour
{
    public float time = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,time);
    }
}
