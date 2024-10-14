using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pausemenu;

    private Dictionary<string, string> statetransformation = new Dictionary<string, string>() 
    { { "Playing", "Paused" }, { "Paused", "Playing" },{"Countdown","CountdownPaused" }, { "CountdownPaused", "Countdown" } };

    private void Start() {
        pausemenu.SetActive(false);
    }

    public void OnClicked() {
        if (statetransformation.ContainsKey(GameStats.gamestate)) {
            Debug.Log("Buttoning"+GameStats.gamestate);

            bool ispaused = GameStats.gamestate.Contains("Paused"); 
            pausemenu.SetActive(!ispaused);

            if (GameStats.gamestate == "Playing") {
                GameEvents.gamepause?.Invoke(); }

            else if (GameStats.gamestate == "Countdown") {
                Time.timeScale = 0; }

            else if (GameStats.gamestate == "Paused") {
                GameEvents.gameunpause?.Invoke(); }

            else if (GameStats.gamestate == "CountdownPaused") {
                Time.timeScale = 2; }

            GameStats.gamestate = statetransformation[GameStats.gamestate];


        }

    }
}
