using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject == PlayerScript.player) {

            orbnimmate();
            GameEvents.orbreached.Invoke();
        }
    }

    void orbnimmate () {
        gameObject.SetActive(false);
    }
}
