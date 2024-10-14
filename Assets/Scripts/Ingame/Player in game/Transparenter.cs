using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparenter : MonoBehaviour
{
    public bool isenabled;
    void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = !isenabled;
    }

}
