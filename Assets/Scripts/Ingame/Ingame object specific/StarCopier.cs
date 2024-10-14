using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCopier : MonoBehaviour
{
    public Vector2 starfieldcount;
    public GameObject starfield;


    void Start()
    {
        float xscale = starfield.transform.localScale.x;
        float yscale = starfield.transform.localScale.y;

        int xsidecount = (int)(starfieldcount.x / 2);
        int ysidecount = (int)(starfieldcount.y / 2);


        for (int i = -xsidecount; i < xsidecount; i ++) {
            for (int j = -ysidecount; j < ysidecount; j ++) {
                GameObject clone = Instantiate(starfield);
                clone.transform.parent = transform;
                float xcoord = xscale * i + xscale / 2;
                float ycoord = yscale * j + yscale / 2;
                clone.transform.position = new Vector3(xcoord, ycoord, starfield.transform.position.z);
            }
        }
    }

}
