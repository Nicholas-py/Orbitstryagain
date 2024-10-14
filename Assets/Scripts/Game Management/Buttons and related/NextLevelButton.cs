using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    public void Start() {
        if (GameStats.level == GlobalData.levelcount) {
            gameObject.SetActive(false);  
        }
    }
    public void OnClick() {
        GameStats.level++;
    }
}
