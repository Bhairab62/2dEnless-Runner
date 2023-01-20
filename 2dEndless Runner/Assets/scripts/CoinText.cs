using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    public Text Coin;
    [HideInInspector]
    public int CoinCollected;
    // Start is called before the first frame update
    void Start()
    {
        Coin = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Coin.text = CoinCollected.ToString();
    }
}
