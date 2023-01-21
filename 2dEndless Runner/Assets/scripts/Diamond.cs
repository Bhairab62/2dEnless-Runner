using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Diamond : MonoBehaviour
{
    public float time;
    //public Text JemsText;
    Animator an;
    private Text jemsText;
    private void Start()
    {
        jemsText = GameObject.FindGameObjectWithTag("jemsText").GetComponent<Text>();
        jemsText.text = PlayerPrefs.GetInt("jems",0).ToString();
        an = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<JemsText>().JemsCollected += 1;
            if (FindObjectOfType<JemsText>().JemsCollected > PlayerPrefs.GetInt("jems", 0))
            {
                PlayerPrefs.SetInt("jems", FindObjectOfType<JemsText>().JemsCollected);
            }   
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
