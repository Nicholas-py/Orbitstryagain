using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuelbarscript : MonoBehaviour
{
    float maxfuel;
    float fuelleft;
    void Start() {
        maxfuel = GameStats.maxfuel;

    }

    void Update()
    {
        fuelleft = GameStats.fuelleft;

        this.GetComponent<Slider>().value = fuelleft/maxfuel;
    }
}
