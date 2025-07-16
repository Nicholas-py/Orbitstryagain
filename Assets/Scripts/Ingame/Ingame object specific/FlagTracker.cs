using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagTracker : MonoBehaviour
{
    public GameObject flag;
    public GameObject player;

    private float xwidth = 300;
    private float yheight = 180;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Hide();
    }

    void FixedUpdate()
    {   
        Vector2 offset = GetOffset();

        if (ShouldDisplay(offset)) {
            float angle = GetAngle(offset);
            GoToAngle(angle);
            Show();
        }

        else {
            Hide();
        }
    }

    bool ShouldDisplay(Vector2 offset) {
        return (offset.x > Screen.height || offset.y > Screen.width);
    }

    Vector2 GetOffset() {
        if (flag != null && player != null) {
            Vector2 offset = flag.transform.position - player.transform.position;
            return offset;
        }
        else {
            return Vector2.zero;
        }
    }

    float GetAngle(Vector2 offset) {
        float angleradians = Mathf.Atan2(offset.y/yheight,offset.x/xwidth);
        return angleradians;
    }

    void GoToAngle(float angleradians) {
        float xpos = xwidth*Mathf.Cos(angleradians);
        float ypos = yheight*Mathf.Sin(angleradians);
        transform.localPosition = new Vector3(xpos, ypos, 0);
        transform.localRotation = Quaternion.Euler(0, 0, angleradians*Mathf.Rad2Deg);
    }

    void Show() {
        spriteRenderer.enabled = true;
    }

    void Hide() {
        spriteRenderer.enabled = false;
    }
}
