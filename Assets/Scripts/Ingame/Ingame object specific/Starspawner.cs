using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starspawner : MonoBehaviour
{
    public GameObject star;
    public GameObject starparent;
    public int count;
    public Vector2 areamin, areamax;
    public float sizemin, sizemax, scalefactor;

    void Start()
    {
        for (int i = 0; i < count; i++) {
            var clone = Instantiate(star);
            clone.transform.parent = starparent.transform;
            clone.transform.position = new Vector2(Random.Range(areamin.x, areamax.x)+starparent.transform.position.x, Random.Range(areamin.y, areamax.y)+starparent.transform.position.y);
            var scale = Mathf.Pow(scalefactor,Random.Range(sizemin, sizemax));
            clone.transform.localScale = RemoveSquishing(new Vector2(scale, scale));
        }
    }

    Vector2 RemoveSquishing(Vector2 inp) {
        Vector2 smallened = new Vector2(inp.x / starparent.transform.localScale.x, inp.y / starparent.transform.localScale.y);
        return smallened * starparent.transform.localScale.magnitude;
    }
}
