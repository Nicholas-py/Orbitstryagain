using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NextPageButton : MonoBehaviour
{
    private ClickThroughMenu parentscript;
    void Start() {
        parentscript = transform.parent.gameObject.GetComponent<ClickThroughMenu>();
    }

    public void NextPage() {
        parentscript.GoToNextPage();
    }

    public void PrevPage() {
        parentscript.GoToPrevPage();
    }


}
