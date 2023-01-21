using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManageMent : MonoBehaviour
{
    [HideInInspector]public GameObject img;
    private void Start()
    {
        img = GameObject.FindGameObjectWithTag("img");
    }
    public void PlayButton()
    {
        Debug.Log("Playing SampleScene");
        StartCoroutine(wait());
    }

    public void ExitButton()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }
    IEnumerator wait()
    {
        img.GetComponent<Animator>().SetTrigger("fade");
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene("SampleScene");
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void HomeButton()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
