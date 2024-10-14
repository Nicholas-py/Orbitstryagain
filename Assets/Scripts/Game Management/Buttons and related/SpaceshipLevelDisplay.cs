using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpaceshipLevelDisplay : MonoBehaviour
{
    TextMeshProUGUI textmesh;
    void Start()
    {
        textmesh = gameObject.GetComponent<TextMeshProUGUI>();
        UpdateDisplay(0);
        GameEvents.levelupspaceship += UpdateDisplay;

    }

    private void OnDestroy() {
        GameEvents.levelupspaceship -= UpdateDisplay;
    }

    public void UpdateDisplay(int pagenumber)
    {
        textmesh.text = "Level " + PlayerData.spaceshiplevels[pagenumber].ToString();
    }
}
