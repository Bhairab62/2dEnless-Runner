using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Animator an;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        an = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<KeyText>().CurrentKeyNum += 1;
            StartCoroutine(DestroyThisKey());
        }
    }
    IEnumerator DestroyThisKey()
    {
        an.SetTrigger("collect");
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
