using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadscene : MonoBehaviour
{    
   
    public void LoadaScene(string scene) {
        GameEvents.leavinglevel?.Invoke(scene);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void LoadCurrentLevel() {
        SceneManager.LoadScene("level");
    }


}
