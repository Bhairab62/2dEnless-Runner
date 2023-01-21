using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    Animator an;
    public float time;
    [HideInInspector]public Text keyText;
    // Start is called before the first frame update
    void Start()
    {
        keyText = GameObject.FindGameObjectWithTag("keyPoint").GetComponent<Text>();
        keyText.text = PlayerPrefs.GetInt("key", 0).ToString();
        an = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<KeyText>().CurrentKeyNum += 1;
            if (FindObjectOfType<KeyText>().CurrentKeyNum > PlayerPrefs.GetInt("key", 0))
            {
                PlayerPrefs.SetInt("key", FindObjectOfType<KeyText>().CurrentKeyNum);
            }
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
