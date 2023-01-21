using UnityEngine.UI;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    public Text HighScoretext;
    int CurrentHighNumber;
    public Text Highscore;
    private void Start()
    {
        Highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    private void FixedUpdate()
    {
        HighScoretext.text = CurrentHighNumber.ToString();
        if (FindObjectOfType<Player>().MaxHealth <= 0)
        {
            Debug.Log("Player Health Has Nothing!!");
            return;
        }
        CurrentHighNumber +=1;
        if (CurrentHighNumber > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", CurrentHighNumber);
        }
    }
}
