using System.Collections;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public float time;
    Animator an;
    private void Start()
    {
        an = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(DestroyDiamond());
        }
    }
    IEnumerator DestroyDiamond()
    {
        an.SetTrigger("collect");//Debug.Log("Diamond Bucket adding one to!!");
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
