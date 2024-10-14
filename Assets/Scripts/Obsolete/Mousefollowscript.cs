using UnityEngine;
public class Mousefollowscript : MonoBehaviour{
    void Update(){
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePosition;}}