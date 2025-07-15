using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelDataHolder : DataHolder
{
    public int level;
    public Vector2 spaceshippos;
    public Vector2 spaceshipspeed;

    public Vector2[] orbs = new Vector2[3];

    public Vector2 framesize = new();

    public OrbitObjectDataHolder[] objects;

    public int flagobject;
    public float flagrotation = 0;
    public float camerasize = 3;
}

[CreateAssetMenu (menuName = "Scriptables/Level")]
public class LevelScriptableObject : ScriptableObject {
    public int level;
    public Vector2 spaceshippos;
    public Vector2 spaceshipspeed;

    public Vector2[] orbs = new Vector2[3];

    public Vector2 framesize = new();

    public OrbitObjectDataHolder[] objects;

    public int flagobject;
    public float flagrotation = 0;
    public float camerasize = 3;

}