using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpriteList : MonoBehaviour {
    public static SpriteList instance = null;
    public bool ismaster;

    public List<Sprite> list = new List<Sprite>() { };

    public void Start() {
        if (ismaster && instance == null) {
            instance = this;
        }
        else { Destroy(this); }
    }

}
