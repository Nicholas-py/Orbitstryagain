using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadscene : MonoBehaviour
{
    public static List<string> levels = new() {"level select page"};
    
    
    public void LoadaScene(string scene) {
        GameEvents.leavinglevel?.Invoke(scene);
        CheckToUpdateLevelNumber(scene);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void LoadCurrentLevel() {
        SceneManager.LoadScene("level");
    }

    void CheckToUpdateLevelNumber(string scene) {
        string lowerscene = scene.ToLower();
        if (levels.Contains(lowerscene)) {
            GameStats.level = levels.IndexOf(lowerscene);
        }

    }

}
