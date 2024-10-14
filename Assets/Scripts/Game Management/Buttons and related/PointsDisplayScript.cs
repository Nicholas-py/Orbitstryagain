using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;

public class PointsDisplayScript : MonoBehaviour
{
    public string endstring;
    private long value;
    private TextMeshProUGUI textbox;

    void Start()
    {
        textbox = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        value = PlayerData.points;
        UpdateText();
    }

    void UpdateText() {
        textbox.text = value.ToString()+endstring;
    }


}
