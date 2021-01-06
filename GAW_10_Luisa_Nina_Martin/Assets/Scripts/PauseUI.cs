using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    bool inPause;
    public GameObject pauseUI;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(this.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!inPause)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
        inPause = true;
        pauseUI.SetActive(true);
    }
    public void Resume() 
    {
        Time.timeScale = 1f;
        inPause = false;
        pauseUI.SetActive(false);
    }
    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
