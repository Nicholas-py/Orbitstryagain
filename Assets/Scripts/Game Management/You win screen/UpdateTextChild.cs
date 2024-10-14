using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTextChild : MonoBehaviour
{
    private GameObject parent;
    private TextMeshProUGUI textmesh;

    [HideInInspector]
    public string variablename;

    private string variablevalue;

    private MonoBehaviour p;

    void Start()
    { 
        textmesh = GetComponent<TextMeshProUGUI>();
        parent = transform.parent.gameObject;
        p = parent.GetComponent<MonoBehaviour>();

        UpdateValue();
        UpdateText();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateText() {
        textmesh.text = variablevalue;
    }

    void UpdateValue() {
        //Internet code, converts string name to value variable with the name variablename has in the parent
        variablevalue = (string)(p.GetType().GetField(variablename).GetValue(p).ToString());
    }
}
