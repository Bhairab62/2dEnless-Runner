using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformGenerater : MonoBehaviour
{
    public GameObject ThePlatform;
    public Transform GeneraterPoint;

    private float PlatformWidth;
    public float DistanceBetween;
    // Start is called before the first frame update
    void Start()
    {
        PlatformWidth = ThePlatform.GetComponent<TilemapCollider2D>().maximumTileChangeCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < DistanceBetween)
        {
            transform.position = new Vector3(transform.position.x + PlatformWidth + DistanceBetween, transform.position.y, transform.position.z);
            Instantiate(ThePlatform, transform.position, transform.rotation);
        }
    }
}
