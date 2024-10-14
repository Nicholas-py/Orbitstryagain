using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using com.cyborgAssets.inspectorButtonPro;



public class PlayerDataHandler : MonoBehaviour {
    private static string filename = "Playerdata";
    private string path;
    private PlayerDataHolder dataholder = new();

    public long pointsdonation;



    void Awake() {
        path = LeveltxtReader.GetGlobalFilePath(filename);
        PlayerData.handler = this;
        if (File.Exists(path)) { 
            dataholder = DataHolder.ReadFromPath<PlayerDataHolder>(path);
        }
        else {
            LeveltxtReader.UpdateData(dataholder, path);
        }
        UpdatePlayerData();
    }

    void UpdatePlayerData() {
        PlayerData.levelunlockedcount = dataholder.levelunlockedcount;
        PlayerData.points = dataholder.points;
        PlayerData.spaceshiplevel = dataholder.spaceshiplevel;
        PlayerData.highscores = dataholder.highscores;
        PlayerData.currentspaceship = dataholder.currentspaceship;
        PlayerData.spaceshiplevels = dataholder.spaceshiplevels;
        if (dataholder.spaceshiplevels[0] == 0) {
            PlayerData.spaceshiplevels[0] = 1;
        }



    }
    PlayerDataHolder GetPlayerDataHolder() {
        PlayerDataHolder dataholder = new PlayerDataHolder();
        dataholder.levelunlockedcount = PlayerData.levelunlockedcount;
        dataholder.points = PlayerData.points;
        dataholder.spaceshiplevel = PlayerData.spaceshiplevel;
        dataholder.highscores = PlayerData.highscores;
        dataholder.currentspaceship= PlayerData.currentspaceship;
        dataholder.spaceshiplevels= PlayerData.spaceshiplevels;
        return dataholder;
    }


    [ProButton]
    public void AddPoints() {
        PlayerData.points += pointsdonation;
        dataholder = GetPlayerDataHolder();
        LeveltxtReader.UpdateData(dataholder, LeveltxtReader.GetGlobalFilePath(filename));
        pointsdonation = 0;
    }



    [ProButton]
    public void ResetPlayerData() {
        LeveltxtReader.UpdateData(new PlayerDataHolder(), LeveltxtReader.GetGlobalFilePath(filename));
        LeveltxtReader.UpdateData(new AchievementDataHolder(), LeveltxtReader.GetGlobalFilePath("Achievements"));
    }

    public void SavePlayer() {
        PlayerDataHolder dataholder = GetPlayerDataHolder();
        LeveltxtReader.UpdateData(dataholder, path);
    }

    

}
