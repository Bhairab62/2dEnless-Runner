using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JemsText : MonoBehaviour{
    public Text jemsText;
    [HideInInspector]public int JemsCollected;
    // Update is called once per frame
    void Update()
    {
        jemsText.text = JemsCollected.ToString();
    }
}
