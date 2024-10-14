using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vectorarrowscript : MonoBehaviour
{
    public GameObject bodytomatch;
    public Vector2 vector;
    void Update()
    {
        transform.position = bodytomatch.transform.position;
        Vector2 vel = bodytomatch.GetComponent<Rigidbody2D>().velocity;
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(vel.y, vel.x)*Mathf.Rad2Deg, Vector3.forward);
        transform.localScale = new Vector2(vel.magnitude,1);

    }
}
