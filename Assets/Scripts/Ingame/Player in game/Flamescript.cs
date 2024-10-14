using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamescript : MonoBehaviour
{
    public List<GameObject> flames = new List<GameObject>();

    private List<SpriteRenderer> flamerenderers = new List<SpriteRenderer>();

    public void Start()
    {
        for (int i = 0; i < flames.Count; i++) {
            flamerenderers.Add(flames[i].GetComponent<SpriteRenderer>());
        }
        ClearFlames();
    }



    public void ClearFlames() {
        for (int i = 0; i < flames.Count; i++) {
            flamerenderers[i].enabled = false;

        }
    }

    public void ChangeFlames(Vector2 xyaccel)
    {
        flamerenderers[0].enabled = xyaccel.y > 0;
        flamerenderers[1].enabled = xyaccel.y < 0;

        flamerenderers[2].enabled = xyaccel.x > 0;
        flamerenderers[3].enabled = xyaccel.x < 0;

    

    }
}
