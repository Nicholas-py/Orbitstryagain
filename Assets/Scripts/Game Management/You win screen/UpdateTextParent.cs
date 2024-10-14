using System.Collections.Generic;
using UnityEngine;

public class UpdateTextParent : MonoBehaviour {
    public List<string> variables = new();

    void Awake() {
        int currentassign = 0;
        for (int i = 0; i < transform.childCount; i++) {
            Transform child = transform.GetChild(i);
            UpdateTextChild childscript = child.GetComponent<UpdateTextChild>();
            if (childscript != null) {
                childscript.variablename = variables[currentassign];
                currentassign++;
            }
        }
    }

}
