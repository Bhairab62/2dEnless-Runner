using UnityEngine.UI;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    public Text HighScoretext;
    int CurrentHighNumber;
    // Update is called once per frame
    void Update()
    {
        HighScoretext.text = CurrentHighNumber.ToString();
    }
    private void FixedUpdate()
    {
        if (FindObjectOfType<Player>().MaxHealth <= 0)
            return;
        CurrentHighNumber += 1;
    }
}
