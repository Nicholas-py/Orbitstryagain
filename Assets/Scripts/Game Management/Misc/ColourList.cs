using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ColourList : MonoBehaviour
{
    public static ColourList instance = null;
    public bool ismaster;

    public List<Color> colours = new List<Color>() { };

    public void Start() {
        if (ismaster && instance == null) {
            instance = this;
        }
        else { Destroy(this); }
    }

}
