using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float time;
    Animator an;
    //private int Totalcoin;
    private Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText = GameObject.FindGameObjectWithTag("coinText").GetComponent<Text>();
        coinText.text=PlayerPrefs.GetInt("coin", 0).ToString();
        an = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<CoinText>().CoinCollected += 1;
            if (FindObjectOfType<CoinText>().CoinCollected > PlayerPrefs.GetInt("coin", 0))
            {
                PlayerPrefs.SetInt("coin", FindObjectOfType<CoinText>().CoinCollected);
            }
            StartCoroutine(Des());
        }
    }
    IEnumerator Des()
    {
        an.SetTrigger("collect");
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
