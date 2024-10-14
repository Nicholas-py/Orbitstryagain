using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementLoader : MonoBehaviour {

    public GameObject defaultcomplete;
    public GameObject defaultincomplete;

    public int firstachievementindex;

    [HideInInspector]
    public int numberperpage; //Set in the ClickThroughAchievements class (should be on the parent of this gameobject)

    private int count;

    void Awake() {
        count = AchievementsData.count;
        TurnOffDefaults();
    }

    public void UpdateButtons(int startindex) {
        firstachievementindex = startindex;
        ClearOldChildren();
        GenerateButtons();
    }

    void GenerateButtons() {
        GameObject current;
        for (int i = 0; i+firstachievementindex < count && i < numberperpage; i++) {
            if (AchievementsData.completed[i + firstachievementindex]) {
                current = Instantiate(defaultcomplete);
            }
            else {
                current = Instantiate(defaultincomplete);
            }
            current.transform.SetParent(transform);
            current.SetActive(true);

            TextMeshProUGUI[] texts = current.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = AchievementsData.prettyachievements[i+firstachievementindex];
            texts[1].text = AchievementsData.description[i+firstachievementindex];

            current.transform.localScale = defaultincomplete.transform.localScale;
            current.transform.localPosition = GetNthCoordinate(i);

        }

    }

    void ClearOldChildren() {
        GameObject child;
        int offset = 0;
        for (int i = 0; i<transform.childCount; i++) {
            child = transform.GetChild(i-offset).gameObject;
            if (child != defaultcomplete && child != defaultincomplete)
            {
                Destroy(child);
            }
        }
    }

    void TurnOffDefaults() {
        defaultincomplete.SetActive(false);
        defaultcomplete.SetActive(false);

    }
    Vector2 GetNthCoordinate(int n) {
        if (n < 4) {
            return new Vector3(-220, 100 - 70 * n, 100) / transform.localScale.x;
        }
        else {
            return new Vector3(220, 28f - 70 * n, 100) / transform.localScale.x;
        }
    }
}
