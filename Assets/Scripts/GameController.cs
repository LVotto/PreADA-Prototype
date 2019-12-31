using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Range(1, 120)]
    public int clock_rate = 20;
    public int timer = 0;
    // Start is called before the first frame update=
    public AnimationCurve moveAnimationCurve;
    public AnimationCurve blinkAnimationCurve;
    public Vector3 origin;
    public float cellSize;
    int ticksElapsed = 0;
    public bool showTimeElapsed;
    public bool isPaused;
    public Vector2Int boardDimensions;
    public Vector2 firstCellCenter;
    public Vector3 camCenter;
    public Camera cam;
    AudioSource bassFX;
    public Material tileMaterial;
    void Start(){
        cam = Camera.main;
        if (showTimeElapsed) Debug.Log(ticksElapsed);
        firstCellCenter = new Vector2 (-boardDimensions.x * cellSize / 2, -boardDimensions.y * cellSize / 2);
        bassFX = GetComponent<AudioSource>();
        bassFX.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown("p")){
            isPaused = !isPaused;
        }
        if (!isPaused && timer == 0 && ticksElapsed < 4) bassFX.Play();
    }

    void FixedUpdate()
    {
        if (!isPaused){
            if(timer < clock_rate) {
                timer++;
            }
            else{
                timer = 0;
                ticksElapsed++;
                if (showTimeElapsed) Debug.Log(ticksElapsed);
            }
        }
    }

    public int getTimer(){
        return timer;
    }
}
