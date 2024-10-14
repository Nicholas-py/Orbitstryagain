using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndOfLevelPage : MonoBehaviour
{
    public int level;
    public float time_taken;
    public string formattime;
    public float fuel_left;
    public string formatfuel;
    public int orbs;
    public int orbscore,fuelscore,timescore;
    public int completescore;
    public int total;

    void Awake()
    {
        BroadcastStats();
        BroadcastScores();
        UpdatePoints();
        UpdateHighscore();
        CheckToIncreaseLevel();
        PlayerData.Save();


    }

    void BroadcastStats() {
        level = GameStats.level;

        orbs = GameStats.orbsgrabbed;

        fuel_left = GameStats.fuelleft;
        formatfuel = FormatFuelLeft(fuel_left);

        time_taken = GameStats.timetaken;
        formattime = FormatTimeTaken(time_taken);

    }
    void BroadcastScores() {
        completescore = CalcCompleteScore();
        orbscore = CalcOrbScore(orbs);
        fuelscore = CalcFuelScore(fuel_left);
        timescore = CalcTimeScore(time_taken);

        total = orbscore + fuelscore + timescore + completescore;

    }

    void CheckToIncreaseLevel() {
        if (GameStats.level == PlayerData.levelunlockedcount) {
            PlayerData.levelunlockedcount++;
        }

    }

    void UpdatePoints() {
        PlayerData.points += total;
    }

    void UpdateHighscore() { 
        int pasthighscore = PlayerData.highscores[level];
        if (total > pasthighscore) {
            PlayerData.highscores[level] = total;
        }
    }

    string FormatTimeTaken(float time) {
        string returner = "";
        int intime = (int)time;
        int seconds = intime % 60;
        int minutes = (intime / 60) % 60;
        int hours = intime / 60 / 60;
        
        if (hours > 0) {
            returner += hours.ToString();
            returner += ":";
            if (minutes < 10) {
                returner += "0";
            }

        }

        returner += minutes.ToString();
        returner += ":";
        if (seconds < 10) {
            returner += "0";
        }
        returner += seconds.ToString();

        return returner;
    }

    string FormatFuelLeft(float fuel) {
        float maxfuel = GameStats.maxfuel;
        string toreturn = ((int)(fuel / maxfuel * 100)).ToString();
        toreturn += "%";
        return toreturn;
    }

    int CalcCompleteScore () {
        return completescore * level;
    }

    int CalcOrbScore(int orbscount) {
        if (orbscount == 0) {
            return 0;
        }
        return (int)(level * 800 * Mathf.Pow(2, orbscount));
    }

    int CalcFuelScore (float fuelleft) {
        float fracspent = 1 - fuelleft / GameStats.maxfuel;
        float score = 1300 / (0.1f + fracspent) - 1300/1.1f;
        return (int)(Math.Max(0,score)*level);
    }

    int CalcTimeScore (float timetaken) {
        float scaledtime = timetaken / 4;
        return (int)(level * 5000 / (1 + scaledtime));
    }

}
