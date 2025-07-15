using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptables/Achievement")]
public class AchievementScriptableObject : ScriptableObject
{
    public string achievementname;
    public string classname;
    public string description;

    public List<int> levels = new List<int>();
    public Sprite image;
}

