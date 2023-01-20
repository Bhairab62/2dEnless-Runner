using UnityEngine.UI;
using UnityEngine;

public class KeyText : MonoBehaviour
{
    public Text Keytext;
    [HideInInspector] public int CurrentKeyNum;

    void Update()
    {
        Keytext.text = CurrentKeyNum.ToString();
    }
}
