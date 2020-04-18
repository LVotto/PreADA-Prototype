﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [Range(1, 120)]

    public AnimationCurve moveAnimationCurve;
    public AnimationCurve blinkAnimationCurve;
    public AudioSource bassFX;

    public float cellSize;

    public Vector3 origin;
    public Vector2Int boardDimensions;
    public Vector2 firstCellCenter;
    public Vector3 camCenter;

    public Material tileMaterial;

    public Camera cam;
    public float yTopSpacing = 2f;
    public float yBottomSpacing = .5f;
    public float xLeftSpacing = .5f;
    public float xRightSpacing = .5f;
    public Vector2 corrections;
    void Awake() {
        bassFX = GetComponent<AudioSource>();
        bassFX.Play();
    }
}
