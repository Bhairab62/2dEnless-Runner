using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Diamond : MonoBehaviour
{
    public float time;
    //public Text JemsText;
    Animator an;
    private void Start()
    {
        an = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<JemsText>().JemsCollected += 1;
            StartCoroutine(DestroyDiamond());
        }
    }
    IEnumerator DestroyDiamond()
    {
        an.SetTrigger("collect");
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
