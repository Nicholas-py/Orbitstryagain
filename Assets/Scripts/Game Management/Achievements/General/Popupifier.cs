using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class Popupifier : MonoBehaviour
{
    public static GameObject instance;
    public TextMeshProUGUI title;
    void Start()
    {
        instance = gameObject;
        title = GetComponentInChildren<TextMeshProUGUI>();
        DontDestroyOnLoad(gameObject);
        GameEvents.achievementgotten += PopUp;
        gameObject.SetActive(false);
    }


    void PopUp(int achievementindex) {
        if (instance != gameObject) {
            GameEvents.achievementgotten -= PopUp;
            Destroy(gameObject);
        }
        title.text = AchievementsData.prettyachievements[achievementindex];
        gameObject.SetActive(true);
        StartCoroutine("Hide");
    }

    IEnumerator Hide() {
        yield return new WaitForSecondsRealtime(3);
        gameObject.SetActive(false);
    }
}
