using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradesPageThrough : ClickThroughMenu
{
    private SpriteRenderer rocket;

    public GameObject title;
    private TextMeshProUGUI titlerenderer;

    private SpaceshipLevelDisplay spaceshipleveldisplay;
    private LevelUpButton levelupbutton;
    private SelectSpaceshipButton selectbutton;

    public GameObject locked;

    public override void Initialize() {
        maxpages = GlobalData.spaceshipcount;

        titlerenderer = title.GetComponent<TextMeshProUGUI>();

        rocket = GetComponentInChildren<SpriteRenderer>();
        spaceshipleveldisplay = GetComponentInChildren<SpaceshipLevelDisplay>();
        levelupbutton = GetComponentInChildren<LevelUpButton>();
        selectbutton = GetComponentInChildren<SelectSpaceshipButton>();

        GameEvents.levelupspaceship += DisplayPage;
    }

    private void OnDestroy() {
        GameEvents.levelupspaceship -= DisplayPage;
    }

    public override void DisplayPage(int pagenumber) {
        rocket.sprite = Spaceships.photos[pagenumber];
        titlerenderer.text = Spaceships.names[pagenumber];

        levelupbutton.currentselection = pagenumber;
        levelupbutton.DisplayCost();

        spaceshipleveldisplay.UpdateDisplay(pagenumber);
        selectbutton.ChangePage(pagenumber);
        Debug.Log(PlayerData.spaceshiplevels[pagenumber]);
        if (PlayerData.spaceshiplevels[pagenumber] == 0) {
            locked.SetActive(true);
        }
        else { locked.SetActive(false); }

    }
}
