using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Levelmanager : MonoBehaviour
{
    public GameObject physicsbox;


    private GameObject displaytextobject;
    private TextMeshProUGUI displaytext;
    public bool messageon;

    void Awake() {
        GameEvents.flagreached += WinGame;
        GameEvents.youlosedisplay += WaitandPause;
        GameEvents.youlosedisplay += GameLostDisplay;
        GameEvents.outoffuel += OnNoFuel;
        GameEvents.orbreached += AddOrb;
        GameEvents.playerexplode += FireYouLoseDisplay;
        GameEvents.gamestart += OnStart;

        GameStats.ResetGameStats();

    }

    void Start()
    {


        GameEvents.physicsonlypause?.Invoke();
        
        displaytextobject =  transform.Find("Canvas").gameObject;
        displaytextobject = displaytextobject.transform.Find("Text").gameObject;
        displaytext = displaytextobject.GetComponent<TextMeshProUGUI>();

        StartCoroutine(CountdownSeconds("Game Start in ",3));
        StartCoroutine(WaitandSend(3,GameEvents.gamestart));

        GameStats.gamestate = "Countdown";
        

    }

    public void OnDestroy() {
        GameEvents.flagreached -= WinGame;
        GameEvents.youlosedisplay -= WaitandPause;
        GameEvents.youlosedisplay -= GameLostDisplay;
        GameEvents.outoffuel -= OnNoFuel;
        GameEvents.orbreached -= AddOrb;
        GameEvents.playerexplode -= FireYouLoseDisplay;
        GameEvents.gamestart -= OnStart;



    }

    IEnumerator CountdownSeconds(string messagetodisplay, int seconds) {
        messageon = true;
        for (int i = 0; i < seconds; i++) {
            displaytext.text = messagetodisplay + (seconds-i).ToString();
            yield return new WaitForSeconds(2);
        }
        displaytext.text = "";
        messageon = false;


    }

    IEnumerator DisplayMessageForInterval(string message, int seconds) {
        Display(message);
        yield return new WaitForSeconds(seconds);
        Display("");

    }

    void Display(string message) {
        messageon = string.IsNullOrWhiteSpace(message);
        displaytext.text = message;
    }



    IEnumerator WaitandSend(float delay, GameEvents.GameEvent message) {
        yield return new WaitForSeconds(2*delay);
        message?.Invoke();

    }

    void PauseGame() {
        GameEvents.gamepause?.Invoke();
    }


    void OnStart() {
        GameStats.gamestate = "Playing";
    }


    void WinGame() {
        GameStats.gamestate = "Won";
        Display("You win!");
        PauseGame();
    }

    void WaitandPause() { 
        StartCoroutine(WaitandSend(5,GameEvents.gamepause));
    }

    void GameLostDisplay() {
        Display("You Lose");

    }

    void OnNoFuel () {
        if (GameStats.gamestate == "Playing") {
            Display("Out of fuel");
        }
    }

    void AddOrb() {
        GameStats.orbsgrabbed += 1;
    }

    void Logg() {
        Debug.Log("Log");
    }

    void FireYouLoseDisplay() {
        if (GameStats.gamestate == "Playing") {
            GameStats.gamestate = "Lost";
            GameEvents.youlosedisplay?.Invoke(); 
        }
    }

}

