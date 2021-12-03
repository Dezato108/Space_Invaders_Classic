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

    public void ChangeSceneToControls()
    {
        SceneManager.LoadScene("ControlsScene");
    }

    public void ChangeSceneToCredits()
    {
        SceneManager.LoadScene("CreditsScene");
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
