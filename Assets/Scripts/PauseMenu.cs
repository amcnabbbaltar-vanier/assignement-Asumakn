using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public Canvas pauseMenu;
    void Start()
    {
        pauseMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }


    public void Pause()
    {
        Time.timeScale = 0;
        Debug.Log("pause");
        pauseMenu.enabled = true;
    }


    public void Play()
    {
        Debug.Log("play");
        Time.timeScale = 1;
        pauseMenu.enabled = false;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
