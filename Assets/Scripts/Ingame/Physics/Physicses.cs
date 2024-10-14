using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Physicses : MonoBehaviour
{
    public List<GameObject> attractors = new();
    public List<GameObject> dynamics = new();
    public ParticleSystem explosionparticles;
    public float gamespeed;

    void Awake() {
        GameEvents.gamestart += BeginPhysics;
        GameEvents.physicsonlypause += StopPhysics;
        GameEvents.gameunpause += BeginPhysics;
        GameEvents.gamepause += StopPhysics;

    }
    void Start() {
        Time.timeScale = gamespeed;
        InitializeObjects();

    }

    public void OnDestroy() {
        GameEvents.gamestart -= BeginPhysics;
        GameEvents.gamepause -= StopPhysics;
        GameEvents.physicsonlypause -= StopPhysics;


    }

    void InitializeObjects() {

        foreach (Transform child in transform) {
            if (child.CompareTag("OrbitingObject")) {
                var objectscript = child.GetComponent<ObjectScript>();
                var childrb = child.GetComponent<Rigidbody2D>();

                childrb.velocity = child.GetComponent<ObjectScript>().startv;

                if (objectscript.explosionparticles == null) {
                    objectscript.explosionparticles = explosionparticles;
                }

                if (objectscript.gravfactor != 0) {
                    dynamics.Add(child.gameObject);
                }
                if (objectscript.g != 0) {
                    attractors.Add(child.gameObject);
                }
            }
        }
    }

    public void BeginPhysics() {
        foreach (Transform child in this.transform) {
            if (child.CompareTag("OrbitingObject")) {
                Rigidbody2D rb = child.GetComponent<Rigidbody2D>();
                rb.simulated = true;
            }
        }
    }

    public void StopPhysics() {
        foreach (Transform child in this.transform) {
            if (child.CompareTag("OrbitingObject")) {
                Rigidbody2D rb = child.GetComponent<Rigidbody2D>();
                rb.simulated = false;
            }
        }
    }

    Vector2 GetPullFrom(GameObject pulled, GameObject puller) {
        float dist = Vector2.Distance(pulled.transform.position, puller.transform.position);
        Vector2 gravdir = (puller.transform.position - pulled.transform.position).normalized;
        float g = puller.gameObject.GetComponent<ObjectScript>().g;   //If game is laggy, replace this GetComponent call with a saved reference somewhere
        Vector2 pull = gravdir * g / (dist * dist);
        return pull;
    }


    void FixedUpdate() { 
        if (GameStats.gamestate == "Playing" || GameStats.gamestate == "Lost") {
            foreach (GameObject orbiter in dynamics) {
                Vector2 totalpull = new Vector2();
                foreach (GameObject puller in attractors) {
                    if (!GameObject.ReferenceEquals(orbiter, puller))

                        totalpull += GetPullFrom(orbiter, puller);
                }
                float gravfactor = orbiter.GetComponent<ObjectScript>().gravfactor;
                Rigidbody2D orbiterbody = orbiter.GetComponent<Rigidbody2D>();
                orbiterbody.AddForce(totalpull * gravfactor * orbiterbody.mass); //Addforce already accounts for Time stuff



            }
        }
    }
}
