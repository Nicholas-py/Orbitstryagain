using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpriteList : MonoBehaviour {
    public static List<Sprite> instance;
    public bool ismaster;

    public List<Sprite> list = new List<Sprite>() { };

    public void Awake() {
        if (ismaster && instance == null) {
            instance = this.list;
        }
        else { Destroy(this); }
    }

}
