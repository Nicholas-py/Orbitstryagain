using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GiveUpButtonscript : MonoBehaviour
{
    private void Awake() {
        Hide();
        GameEvents.outoffuel += Show;
        GameEvents.flagreached += Hide;
        GameEvents.youlosedisplay += Hide;
        GameEvents.playerexplode += Hide;
        


    }
    public void OnClicked() {
        GameEvents.youlosedisplay.Invoke();
    }

    public void OnDestroy() {
        GameEvents.outoffuel -= Show;
        GameEvents.flagreached -= Hide;
        GameEvents.youlosedisplay -= Hide;
        GameEvents.playerexplode -= Hide;

    }

    void Show() {
        gameObject.SetActive(true);
    }

    void Hide() {
        gameObject.SetActive(false);
    }
}
