using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class physicsScript : MonoBehaviour {
    public Vector2 speedvector = new Vector2(0, -1);
    public GameObject thisguy = null;
    private Transform parent = null;
    public List<GameObject> attractors = new List<GameObject>() { };
    public float gamespeed = 1;


    void Start() {
        thisguy.GetComponent<Rigidbody2D>().velocity = speedvector;

        parent = thisguy.transform.parent;
        foreach (Transform child in parent.transform) {
            if (child.tag == "HasGravity") {
                attractors.Add(child.gameObject);
               
            }
        }
        //Time.timeScale = gamespeed;
    }

    Vector2 PullFrom(GameObject obj) {
        float dist = Vector2.Distance(obj.transform.position,thisguy.transform.position);
        //Debug.Log(dist + "obj:", obj.gameObject);
        Vector2 gravdir = (obj.transform.position-thisguy.transform.position).normalized;
        float g = obj.gameObject.GetComponent<ObjectScript>().g;
        Vector2 pull = gravdir * g / (dist * dist);
        //Debug.Log(obj +", "+ pull);
        return pull;
    }

// Update is called once per frame
    void Update() {
        Vector2 totalpull = new Vector2(0, 0);
        foreach (GameObject obj in attractors) {
            totalpull += PullFrom(obj);
        }
        thisguy.GetComponent<Rigidbody2D>().AddForce(Time.deltaTime * Time.timeScale * totalpull);
    }
}
