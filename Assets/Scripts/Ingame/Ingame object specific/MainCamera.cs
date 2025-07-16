using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public static Camera cam;

    private void Start() {
        if (cam == null) {
            cam = GetComponent<Camera>();
        }
        else {
            Destroy(this);
        }
    }
}
