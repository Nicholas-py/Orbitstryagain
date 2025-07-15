using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementList : MonoBehaviour {

    public List<AchievementScriptableObject> list;



    public static AchievementList instance = null;
    public bool ismaster;


    public void Start() {
        if (ismaster && instance == null) {
            instance = this;
        }
        else { Destroy(this); }
    }

}