using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowkeysscript : MonoBehaviour {
    public Rigidbody2D rb;
    public float movespeed;
    public Flamescript flamescript;
    public int movemode;


    private bool fuelalreadyranout = false;
    private Vector2 oldposition;

    void Start() {
        oldposition = rb.position;
        
    }


    void FixedUpdate() {

        if (GameStats.gamestate != "Playing") {
            return;
        }

        float fuelleft = GetFuel();

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 rawinput = new Vector2(x, y);

        if (rawinput == Vector2.zero) {
            flamescript.ClearFlames();
        }
        else if (fuelleft <= 0) {
            flamescript.ClearFlames();
            if (!fuelalreadyranout && GameStats.gamestate == "Playing") {
                GameEvents.outoffuel?.Invoke();
                fuelalreadyranout = true;
            }
        }
        else  {
            UpdateFuel(rawinput);

            flamescript.ChangeFlames(rawinput);

            Vector2 motion = GetInputForces(rawinput);
            rb.AddForce(motion);
            }

        UpdateStats();

    }

    void UpdateStats() {
        UpdateDistanceStats();
        UpdateFuelStats();
        UpdateTimeStats();
       }


    void UpdateDistanceStats() {
        Vector2 dchange = oldposition - rb.position;
        float distance = dchange.magnitude;
        GameStats.distancetraveled += distance;
        oldposition = rb.position;
    }

    void UpdateFuelStats() {
        GameStats.fuelleft = GetFuel();
    }

    void UpdateTimeStats() {
        GameStats.timetaken += Time.deltaTime;
    }
     void UpdateFuel(Vector2 rawinput) {
        float fuelleft = GetFuel();
        fuelleft -= rawinput.magnitude;
        GameStats.fuelleft -= rawinput.magnitude;

    }


    float GetFuel() {
        return GameStats.fuelleft;
    }
    Vector2 GetInputForces (Vector2 rawinput) {
        Vector2 xy;

        if (movemode == 0) {
            xy = MoveMode0(rawinput);
        }

        else if (movemode == 1) {
            xy = MoveMode1(rawinput);
        }


        else if (movemode == 2) {
            xy = MoveMode2(rawinput);
        }

        else {
            throw new Exception("Move mode doesn't exist");
        }

        return xy * movespeed;
    }

    Vector2 MoveMode0(Vector2 rawmotion) {
        return rawmotion;
    }

    Vector2 MoveMode1 (Vector2 rawmotion) {
        Vector2 vel = rb.velocity;
        Vector2 dir = vel.normalized;
        Vector2 horizmotion = dir - rotate(dir, rawmotion.x*2*Mathf.PI);
        Vector2 vertmotion = new Vector2(0, 0);
        if (vel.magnitude > 0.02 | rawmotion.y > 0) {
            vertmotion = dir * rawmotion.y;
        }
        return vertmotion + horizmotion;


    }

    Vector2 MoveMode2(Vector2 rawmotion) {
        float spritedirection = Mathf.Atan2(rb.velocity.y, rb.velocity.x) - 90;

        Vector2 polarmotion = Polar(rawmotion);
        polarmotion.y += spritedirection;

        Vector2 motion = Rectangular(polarmotion);
        return motion;



    }

    Vector2 rotate(Vector2 v, float delta) {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }

    Vector2 Polar(Vector2 rectangular) { 
        float r = rectangular.magnitude;
        float theta = Mathf.Atan2(rectangular.y, rectangular.x);
        return new Vector2(r, theta);
    }

    Vector2 Rectangular(Vector2 polar) {
        float x = polar.x * Mathf.Cos(polar.y);
        float y = polar.x * Mathf.Sin(polar.y);
        return new Vector2(x, y);
    }

}

