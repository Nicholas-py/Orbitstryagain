using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagTracker : MonoBehaviour {
    public GameObject flag;
    public GameObject player;

    private float xwidth = 300;
    private float yheight = 180;

    private SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Hide();
    }

    void FixedUpdate() {

        if (ShouldDisplay()) {
            Vector2 offset = flag.transform.position - player.transform.position;
            float angle = Mathf.Atan2(offset.y / yheight, offset.x / xwidth); ;
            GoToAngle(angle);
            Show();
        }

        else {
            Hide();
        }
    }

    bool ShouldDisplay() {
        if (flag == null || player == null) {
            return false;
        }

        Vector2 coords = MainCamera.cam.WorldToViewportPoint(flag.transform.position);
        if (coords.x < 0 || coords.x > 1 || coords.y < 0 || coords.y > 1) {
            return true;
        }
        return false;
    }


    void GoToAngle(float angleradians) {
        float xpos = xwidth * Mathf.Cos(angleradians);
        float ypos = yheight * Mathf.Sin(angleradians);
        transform.localPosition = new Vector3(xpos, ypos, 0);
        transform.localRotation = Quaternion.Euler(0, 0, angleradians * Mathf.Rad2Deg);
    }

    void Show() {
        spriteRenderer.enabled = true;
    }

    void Hide() {
        spriteRenderer.enabled = false;
    }
}
