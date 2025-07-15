using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptables/Image")]
public class ImageData : ScriptableObject {
    public Sprite image;
    public Vector2 coords;
    public Vector2 scale;
}