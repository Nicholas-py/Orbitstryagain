using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceships : MonoBehaviour 
{
    [SerializeField]
    private List<string> inspectornames;

    [SerializeField]
    private List<Sprite> inspectorphotos;
    


    public static List<string> names;
    public static List<Sprite> photos;

    void Awake()
    {
        names = inspectornames;
        photos = inspectorphotos;

    }

}
