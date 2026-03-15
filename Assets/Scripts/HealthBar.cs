using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   

    Slider bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Slider>();
        bar.maxValue = 3;
    }

    // Update is called once per frame
    void Update()
    {
        bar.value = GameManager.playerHealth;
        if(GameManager.playerHealth <= 0)
        {   
            GameManager.playerHealth =  3;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
