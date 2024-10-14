using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



//To use, create a gameobject with a script derived from ClickThroughMenu and choose a Dataholder type for it
//Then assign a display function and change the GetPage function to use your new datatype
//Then, create  next/prevpagebutton as children
public abstract class ClickThroughMenu : MonoBehaviour {
    private int currentpagenum = 0;

    public GameObject nextbutton;
    public GameObject prevbutton;

    [HideInInspector]public int maxpages;


    void Start() {
        Initialize();
        SetButtonsActive();
        DisplayPage(currentpagenum);
    }

    public void GoToNextPage() {
        currentpagenum++;

        SetButtonsActive();
        DisplayPage(currentpagenum);

    }

    public void GoToPrevPage() {
        currentpagenum--;

        SetButtonsActive();
        DisplayPage(currentpagenum);

    }

    protected void SetButtonsActive() {
        if (currentpagenum >= maxpages - 1) {
            nextbutton.SetActive(false);
        }
        else {
            nextbutton.SetActive(true);
        }
        if (currentpagenum == 0) {
            prevbutton.SetActive(false);
        }
        else {
            prevbutton.SetActive(true);
        }


    }




    public abstract void DisplayPage(int pagenumber);

    public abstract void Initialize(); 

    
}

