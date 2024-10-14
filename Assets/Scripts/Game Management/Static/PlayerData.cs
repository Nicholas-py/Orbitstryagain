using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Store any persistant data here, this stays between playthroughs
public class PlayerData
{
    public static PlayerDataHandler handler;
    public static int levelunlockedcount;
    public static long points;
    public static int[] highscores;

    public static int spaceshiplevel;
    public static int[] spaceshiplevels;
    public static int currentspaceship;

    public static void Save() {
        handler.SavePlayer();
    }
}


public class PlayerDataHolder : DataHolder {
    public int levelunlockedcount = 1;
    public long points = 0;
    public int spaceshiplevel = 1;
    public int[] highscores = new int[GlobalData.levelcount + 1];

    public int currentspaceship = 0;
    public int[] spaceshiplevels = new int[GlobalData.spaceshipcount];

}