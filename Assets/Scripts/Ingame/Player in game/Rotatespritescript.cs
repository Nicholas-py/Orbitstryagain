using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatespritescript : MonoBehaviour
{
    public float uprotation;
    public GameObject torotate;
    private Rigidbody2D rigidbody2d;
    void Start()
    {
        rigidbody2d = torotate.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var v = rigidbody2d.velocity;
        var dir = Mathf.Atan2(v.y , v.x)*Mathf.Rad2Deg - uprotation;
        float prevrotation = rigidbody2d.rotation;
        torotate.transform.Rotate(Vector3.forward * (-prevrotation+ dir));
        


    }
}
