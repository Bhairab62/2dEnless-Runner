using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManageMent : MonoBehaviour
{
    public GameObject img;
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
}
