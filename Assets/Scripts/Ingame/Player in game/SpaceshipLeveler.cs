using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceshipLeveler : MonoBehaviour
{
    private Arrowkeysscript arrowkeysscript;
    private KindOfShipHandler kindOfShipHandler;
    void Start()
    {
        kindOfShipHandler = GetComponent<KindOfShipHandler>();
        arrowkeysscript = GetArrowkeysscript();
        GameStats.maxfuel = kindOfShipHandler.CalcStartingFuel(PlayerData.spaceshiplevel);
        GameStats.fuelleft = GameStats.maxfuel;
        arrowkeysscript.movespeed = kindOfShipHandler.CalcThrust(PlayerData.spaceshiplevel);

    }


    Levelmanager GetLevelmanager() { 
        GameObject grandparent = transform.parent.parent.gameObject;
        return grandparent.GetComponent<Levelmanager>();
    }

    Arrowkeysscript GetArrowkeysscript() {
        return gameObject.GetComponent<Arrowkeysscript>();
    }
}
