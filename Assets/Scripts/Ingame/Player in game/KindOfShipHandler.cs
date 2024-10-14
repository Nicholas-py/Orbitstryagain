using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KindOfShipHandler : MonoBehaviour
{
    private SpaceshipType[] spaceships = new SpaceshipType[GlobalData.spaceshipcount] {new BasicSpaceship(),new FuelFiller()};
    private int spaceshiptype;

    private SpriteRenderer spriteRenderer;
    void Awake() {
        spaceshiptype = PlayerData.currentspaceship;

    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Spaceships.photos[spaceshiptype];
        Debug.Log(spaceshiptype);
    }

    public float CalcStartingFuel(int level) {
        return spaceships[spaceshiptype].CalcStartingFuel(level);
    }

    public float CalcThrust(int level) {
        return spaceships[spaceshiptype].CalcThrust(level);
    }

}
