using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Store any data that resets when you restart the game here
public class GameStats
{
    public static float timetaken = 0;
    public static float fuelleft = 0;
    public static float distancetraveled = 0;

    public static int orbsgrabbed = 0;

    public static int level = 0;
    public static float maxfuel = 300;

    public static int currentspaceshiplevel;

    public static string gamestate = "Initializing";

    public static void ResetGameStats () {
        timetaken = 0f;
        distancetraveled = 0f;
        orbsgrabbed = 0;
        gamestate = "Initializing";
    }
}
