using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{

    ParticleSystem ps;

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject == PlayerScript.player) {
            orbnimmate();
            PlayerData.points += GameStats.level*500;
            PlayerData.Save();
            GameEvents.orbreached.Invoke();
        }
    }

    void orbnimmate () {
        ps = gameObject.GetComponent<ParticleSystem>();
        ps.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

    }
}
