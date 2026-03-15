using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTimer : MonoBehaviour
{

    Text TimerText;
    // Start is called before the first frame update
    void Start()
    {
        TimerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = "Time: " + Math.Round((Decimal)GameManager.timer, 0);
    }
}
