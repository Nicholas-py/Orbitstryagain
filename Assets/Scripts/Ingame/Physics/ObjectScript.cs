using System.Collections;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{

    public float g;
    public Vector2 startv = new Vector2();
    public float gravfactor;

    public bool flagsafe;
    public bool triggersexplosions = true;
    public bool canexplode = true;


    public float explodespeedfactor;
    public ParticleSystem explosionparticles;

    public bool isrotating = false;

    [HideInInspector]
    public Sprite sprite;

    private Vector2 vel;
    private Vector2 pos;
    private Rigidbody2D rigid;

    private bool isplayer = false;


    private void Start() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (sprite != null) {
            spriteRenderer.sprite = sprite;
        }
        rigid = GetComponent<Rigidbody2D>();
        if (isrotating) { 
            Rotatespritescript rotator = gameObject.AddComponent<Rotatespritescript>();
            rotator.torotate = gameObject;
            rotator.uprotation = transform.localEulerAngles.z;
        }
        if (gameObject.GetComponent<PlayerScript>() != null) { 
            isplayer = true;
        }
    }


    private void FixedUpdate() {
        vel = rigid.velocity;
        pos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (isplayer && (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "OrbitingObject")) {
            GameEvents.explosion?.Invoke(gameObject);
            explode();
            return;
        }

        rigid.velocity = vel;
        transform.position = pos;
        if (collision.gameObject.tag == "OrbitingObject") {
            ObjectScript otherscript = collision.gameObject.GetComponent<ObjectScript>();
            if (otherscript.triggersexplosions && canexplode) {
                GameEvents.explosion?.Invoke(gameObject);
                explode();
            }

            else if (!otherscript.canexplode || !triggersexplosions) {
                BounceOffObject(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Wall") {
            BounceOffWall(collision.gameObject);

        }

    }

    void BounceOffObject(GameObject obj) { 
        //For now, just pass through each other
    }

    void BounceOffWall(GameObject wall) {
        if (wall.transform.position.x == 0) {
            rigid.velocity = new Vector2(vel.x, -vel.y);
        }
        else {
            rigid.velocity = new Vector2(-vel.x, vel.y);

        }

    }

    public void explode () {
        try {
            transform.parent.GetComponent<Physicses>().attractors.Remove(this.transform.gameObject);
            transform.parent.GetComponent<Physicses>().dynamics.Remove(this.transform.gameObject);
        }
        catch (Exception e) {
            Debug.Log(e.ToString());
        }
        ParticleSystem particles = Instantiate(explosionparticles);
        particles = SetUpParticles(particles);
        particles.Play();

        Destroy(gameObject,particles.main.duration);
    }


    ParticleSystem SetUpParticles(ParticleSystem particles) {
        particles.transform.position = this.transform.position;

        Vector2 thisvel = this.transform.GetComponent<Rigidbody2D>().velocity;

        var particlevel = particles.velocityOverLifetime;
        particlevel.x = new ParticleSystem.MinMaxCurve(thisvel.x * explodespeedfactor);
        particlevel.y = new ParticleSystem.MinMaxCurve(thisvel.y * explodespeedfactor);


        return particles;


    }


}
