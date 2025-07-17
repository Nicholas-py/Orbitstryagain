using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouLoseButton : MonoBehaviour {
    void Start() {
        Hide();
        GameEvents.youlosedisplay += Show;
        GameEvents.flagreached += Hide;
    }

    void OnDestroy() {
        GameEvents.youlosedisplay -= Show;
        GameEvents.flagreached -= Hide;
    }
    void Show() {
        gameObject.SetActive(true);
    }

    void Hide() {
        gameObject.SetActive(false);
    }

}
