using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSpaceshipButton : MonoBehaviour
{
    private int currentpage;
    void Start()
    {
        
    }

    public void ChangePage(int page) {
        if (PlayerData.spaceshiplevels[page] == 0 || PlayerData.currentspaceship == page) {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else {
            gameObject.GetComponent<Button>().interactable = true;

        }
        currentpage = page;
    }

    public void OnClick() {
        PlayerData.currentspaceship = currentpage;
        PlayerData.Save();
        gameObject.GetComponent<Button>().interactable = false;

    }
}
