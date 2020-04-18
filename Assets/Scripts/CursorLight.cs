using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLight : MonoBehaviour
{
    Camera cam;
    public float lightDepth;
    GameController gameController;
    void Start()
    {
        cam = Camera.main;
        gameController = GetComponentInParent<GameController>();
    }
    void Update()
    {
        transform.position = MouseToScreen();
    }

    Vector3 MouseToScreen(){
        Vector3 depth = new Vector3(0, 0, lightDepth);
        Vector3 new_pos = cam.ScreenToWorldPoint(Input.mousePosition) + depth;
        new_pos.x = gameController.cellSize 
                  * Mathf.Round(new_pos.x + gameController.corrections.x)
                  - gameController.corrections.x;
        new_pos.y = gameController.cellSize * Mathf.Round(new_pos.y
                  + gameController.corrections.y)
                  - gameController.corrections.y;
        return new_pos;  
    }
}
