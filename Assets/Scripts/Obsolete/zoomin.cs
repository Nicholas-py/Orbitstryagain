using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomin : MonoBehaviour
{
    public GameObject cameratozoom;
    void FixedUpdate()
    {
        cameratozoom.GetComponent<Camera>().orthographicSize *= 0.9995f;
    }
}
