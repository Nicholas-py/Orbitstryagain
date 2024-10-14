using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{


    public static GameObject player;

    void Start()
    {
        GameEvents.explosion += onexplosion;
        if (player == null) {
            player = this.gameObject;
        }
    }

    void OnDestroy() {
        GameEvents.explosion -= onexplosion;
    }


    void onexplosion (GameObject exploder) {
        if (exploder == this.gameObject) {
            GameEvents.playerexplode?.Invoke();
        }
    }
}
