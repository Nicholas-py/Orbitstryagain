using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlagScript : MonoBehaviour
{

    public GameObject player;
    private GameObject attachedobject;

    public void Start() {
        attachedobject = transform.parent.gameObject;
    }

    public void Update() {
           transform.position = attachedobject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject collider = collision.gameObject;

        if (GameObject.ReferenceEquals(collider, player) && GameStats.gamestate == "Playing") {
            GameEvents.flagreached?.Invoke();
        }

        else {
           try {
                ObjectScript script = collider.GetComponent<ObjectScript>();
                if (!script.flagsafe) {
                    collider.GetComponent<ObjectScript>().explode();
                }
            }
            catch { }
        }
    }
}
