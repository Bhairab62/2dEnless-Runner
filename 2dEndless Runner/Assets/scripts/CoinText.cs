using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    public Text Coin;
    //public Text TotalCoin;
    [HideInInspector]
    public int CoinCollected;
    // Start is called before the first frame update
    void Start()
    {
        Coin = gameObject.GetComponent<Text>();
        //TotalCoin.text=PlayerPrefs.GetInt("coin", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Coin.text = CoinCollected.ToString();
    }
}
