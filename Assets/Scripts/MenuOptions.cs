using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            
    }

   public void PlayGame()
    {       
        GameManager.timer = 0;
        GameManager.Score = 0; 
        SceneManager.LoadScene("Level-1");
    }

    public void ExitGame()
    {
        
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }


}
