using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TitleText {
    public string title;
    public string text;
}

[CreateAssetMenu(menuName = "Scriptables/Help")]
public class HelpScriptableObject : ScriptableObject
{
    public List<TitleText> data;
    public List<ImageData> images;

}
