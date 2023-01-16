using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformGenerater : MonoBehaviour
{
    public GameObject ThePlatform;
    public Transform GeneraterPoint;
    public Transform[] points;
    private float PlatformWidth;
    public float DistanceBetween;
    // Start is called before the first frame update
    void Start()
    {
        PlatformWidth = ThePlatform.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x<GeneraterPoint.position.x)
        {
            float RandomYvalue = Mathf.Clamp(this.transform.position.y, -2f,-1.5f);
            transform.position = new Vector3(transform.position.x + PlatformWidth + DistanceBetween,RandomYvalue, transform.position.z);
            Instantiate(ThePlatform,transform.position, transform.rotation);
        }
    }
}
