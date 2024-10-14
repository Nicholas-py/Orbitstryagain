using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadButton : MonoBehaviour
{
    public int level;
    private TextMeshProUGUI text;
    private TextMeshProUGUI highscore;
    void Start() {
        text = GetComponentsInChildren<TextMeshProUGUI>()[0];
        text.text = "LEVEL " + level.ToString();
        highscore = GetComponentsInChildren<TextMeshProUGUI>()[1];
        highscore.text = PlayerData.highscores[level].ToString();
    }
    public void OnClicked() {
        GameStats.level = level;
        SceneManager.LoadScene("level");
    }
}
