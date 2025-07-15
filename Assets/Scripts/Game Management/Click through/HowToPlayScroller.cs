using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HowToPlayScroller : ClickThroughMenu
{
    public HelpScriptableObject data;

    public TextMeshProUGUI title;
    public TextMeshProUGUI text;
    public GameObject image;
    private Sprite sprite;

    public override void Initialize() {
        maxpages = data.data.Count;
        sprite = image.GetComponent<Sprite>();
    }

    public override void DisplayPage(int pagenum) {
        title.text = data.data[pagenum].title;
        text.text = data.data[pagenum].text;   
        sprite = data.images[pagenum].image;
        image.transform.position = data.images[pagenum].coords;
    }


}
