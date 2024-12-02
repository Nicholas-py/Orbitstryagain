using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Preset values (public bool isrotating = false instead of public bool isrotating) are defaults
[Serializable]
public class OrbitObjectDataHolder : DataHolder 
    {
    public float gravity;
    public float gravityeffects;

    public Vector2 startvelocity;
    public float scale;
    public Vector2 position;

    public bool flagsafe = true;

    public bool triggersexplosions = true;
    public bool canexplode = true;
    public float explodespeedfactor = 1;

    public bool isrotating = false;

    public Sprite sprite;


    public static OrbitObjectDataHolder GetDataHolder(ObjectScript orbiterscript) {
        OrbitObjectDataHolder dataholder = new() {
            position = orbiterscript.transform.position,
            scale = orbiterscript.transform.localScale.x,
            startvelocity = orbiterscript.startv,

            gravity = orbiterscript.g,
            gravityeffects = orbiterscript.gravfactor,

            flagsafe = orbiterscript.flagsafe,
            canexplode = orbiterscript.canexplode,
            triggersexplosions = orbiterscript.triggersexplosions,

            explodespeedfactor = orbiterscript.explodespeedfactor,
            isrotating = orbiterscript.isrotating,
            sprite = orbiterscript.gameObject.GetComponent<SpriteRenderer>().sprite



        };

        return dataholder;
    }

    public static void UpdateObject(OrbitObjectDataHolder dataholder, ObjectScript orbiterscript) {
        orbiterscript.transform.localPosition = new Vector3(dataholder.position.x,dataholder.position.y,orbiterscript.transform.position.z);
        orbiterscript.transform.localScale = new Vector2(dataholder.scale,dataholder.scale);
        orbiterscript.startv = dataholder.startvelocity;

        orbiterscript.g = dataholder.gravity;
        orbiterscript.gravfactor = dataholder.gravityeffects;

        orbiterscript.flagsafe = dataholder.flagsafe;
        orbiterscript.canexplode = dataholder.canexplode;
        orbiterscript.triggersexplosions = dataholder.triggersexplosions;

        orbiterscript.explodespeedfactor = dataholder.explodespeedfactor;
        orbiterscript.isrotating = dataholder.isrotating;

        orbiterscript.sprite = dataholder.sprite;


    }
}

