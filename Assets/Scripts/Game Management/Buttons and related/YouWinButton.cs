using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWinButton : MonoBehaviour
{
    void Start()
    {
        Hide();
        GameEvents.flagreached += Show;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        GameEvents.flagreached -= Show;
    }
    void Show() {
        gameObject.SetActive(true);
    }

    void Hide() {
        gameObject.SetActive(false);
    }

}
