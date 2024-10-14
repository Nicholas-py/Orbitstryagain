using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class GameEvents
{

    public delegate void GameEvent();
    public delegate void GameEvent<T>(T gameobj);

    public static GameEvent physicsonlypause;
    public static GameEvent gamepause;
    public static GameEvent gameunpause;
    public static GameEvent gamestart;
    public static GameEvent youlosedisplay;

    public static GameEvent orbreached;
    public static GameEvent flagreached;

    public static GameEvent<GameObject> explosion; 
    public static GameEvent playerexplode;

    public static GameEvent outoffuel;
    public static GameEvent<String> leavinglevel; //string is the name of the level 

    public static GameEvent<int> achievementgotten; //int is the index of the achievement

    public static GameEvent<int> levelupspaceship;


}
