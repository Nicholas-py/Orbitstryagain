using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.Examples;
using System.Linq;

public class LevelUpButton : MonoBehaviour
{
    public int upgradecostthousands;
    private int cost;
    private const int thousand = 1000;

    public int currentselection;
    public GameObject costdisplay;
    public GameObject buttontextobject;
    private TextMeshProUGUI textmesh;
    private TextMeshProUGUI buttontext;

    void Start()
    {
        textmesh = costdisplay.GetComponent<TextMeshProUGUI>();
        buttontext = buttontextobject.GetComponent<TextMeshProUGUI>();

        UpdateCost();
        DisplayCost();
    }

    public void OnClick() {
        PlayerData.points -= cost;
        PlayerData.spaceshiplevels[currentselection]++;
        PlayerData.Save();
        GameEvents.levelupspaceship?.Invoke(currentselection);
        UpdateCost();
        DisplayCost();
    }

    private void UpdateCost() {
        if (PlayerData.spaceshiplevels[currentselection] > 0) {
            cost = PlayerData.spaceshiplevels[currentselection] * upgradecostthousands * (currentselection+1) * thousand;
        }
        else {
            cost = 75*thousand;
        }
    }

    public void DisplayCost() {
        UpdateCost();
        if (PlayerData.spaceshiplevels[currentselection] == 0) {
            buttontext.text = "Unlock";
        }
        else {
            buttontext.text = "Level UP";
        }

        if (PlayerData.points <= cost) {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else {
            gameObject.GetComponent<Button>().interactable = true;
        }
        textmesh.text = SpaceNumber(cost) + " pts";
    }

    string SpaceNumber(int number) {
        string basestring = number.ToString();
        string returnstring = string.Empty;
        for (int i = basestring.Length - 1; i >= 0; i--) {
            if ((basestring.Length-i)%3 == 1) {
                returnstring = string.Concat(basestring[i], " ", returnstring);
            }
            else { returnstring = string.Concat(basestring[i], returnstring); }
        }
        return returnstring;
    }
}
