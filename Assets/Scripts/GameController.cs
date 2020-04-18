﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Range(1, 120)]
    

    public AnimationCurve moveAnimationCurve;
    public AnimationCurve blinkAnimationCurve;

    
    public float cellSize;

    public Vector3 origin;
    public Vector2Int boardDimensions;
    public Vector2 firstCellCenter;
    public Vector3 camCenter;
    public Camera cam;
    
    public Material tileMaterial;

    void Start(){
        cam = Camera.main;
        
        firstCellCenter = new Vector2 (-boardDimensions.x * cellSize / 2, -boardDimensions.y * cellSize / 2);
        //bassFX = GetComponent<AudioSource>();
        //bassFX.Play();
    }





  public int getTimer() {
    return 100;
  }
}
