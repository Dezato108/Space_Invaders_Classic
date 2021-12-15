using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIControl : MonoBehaviour
{

    public Animator transition;
    public GameObject CrossFade;
    public void ChangeSceneToPlay()
    {
        LoadNextLevel();
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }

    private void Awake()
    {
        CrossFade.SetActive(true);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(1f);
        Debug.Log("play animation");
        SceneManager.LoadScene(levelIndex);
    }

    public void ChooseLevel1()
    {
        StartCoroutine(LoadLevel(1));
    }
    public void ChooseLevel2()
    {
        StartCoroutine(LoadLevel(2));
    }
    public void ChooseLevel3()
    {
        StartCoroutine(LoadLevel(3));
    }
    public void ChooseLevel4()
    {
        StartCoroutine(LoadLevel(4));
    }
    public void ChooseLevel5()
    {
        StartCoroutine(LoadLevel(5));
    }
    public void ChooseLevel6()
    {
        StartCoroutine(LoadLevel(6));
    }
    public void ChooseLevel7()
    {
        StartCoroutine(LoadLevel(7));
    }
    public void ChooseLevel8()
    {
        StartCoroutine(LoadLevel(8));
    }
    public void ChooseLevel9()
    {
        StartCoroutine(LoadLevel(9));
    }
    public void ChooseLevel10()
    {
        StartCoroutine(LoadLevel(10));
    }
}
