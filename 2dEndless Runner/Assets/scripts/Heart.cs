using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    Animator an;
    // Start is called before the first frame update
    void Start()
    {
        an = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(WaitToDestroy());
        }
    }
    IEnumerator WaitToDestroy()
    {
        an.SetTrigger("fade");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
