using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    // Start is called before the first frame update
    public static int Score;
    public static int playerHealth = 3;

    public static float timer = 0;
    public static void  incrementScore(int amount)
    {
        Score += amount;
    }

    public static void  incrementScore()
    {
        Score++;
    }


    public static void  DamagePlayer(int amount)
    {
        playerHealth -= amount;
    }

    public static void  DamagePlayer()
    {
        playerHealth--;
    }
}
