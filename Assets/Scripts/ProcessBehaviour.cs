using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessBehaviour : MonoBehaviour
{
    GameController gameController;
    Light light_;
    float timer;
    float rate;
    float t;
    AnimationCurve blinkAnimationCurve;
    LinkedList<Instruction> instructions = new LinkedList<Instruction>();
    LinkedListNode<Instruction> currentInstruction;
    bool loop = false;
    Collider processCollider;
    AudioSource killSource;
    public GameObject dyingLightPrefab;
    public Vector3 nextPosition;

    public Vector2 relativeCoordinates(){
        Vector2 pos2d = new Vector2 (transform.position.x, transform.position.y);
        pos2d += new Vector2 (gameController.origin.x, gameController.origin.y);
        return pos2d;
    }

    public Vector2Int boardCoordinates(){
        Vector2 pos2d = relativeCoordinates();
        pos2d = Vector2Int.zero; //
        return Vector2Int.zero;
    }

    public void Kill(){
        Vector3 dyingPosition = Vector3.ProjectOnPlane(transform.position, Vector3.back) + 1.5f * Vector3.forward;
        GameObject dyingLightObj = Instantiate(dyingLightPrefab, dyingPosition, Quaternion.identity);
        killSource.Play();
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void LoadInstructions(){
        instructions = new LinkedList<Instruction>();
        List<Vector3> dirs = new List<Vector3> { 
            Vector3.up, Vector3.left 
        };
        foreach(Vector3 v in dirs){
            MoveInstruction instr = new MoveInstruction(gameController,
                                                        this.gameObject,
                                                        v); 
            instructions.AddLast(instr);
        }
    }

    void ResetInstructions(){
        LinkedListNode<Instruction> ci = instructions.First;
        while(ci != null){
            Instruction c = ci.Value;
            c.isDone = false;
            c.hasStarted = false;
            ci = ci.Next;
        }
    }

    void TestDummyStart(){
        LoadInstructions();
        loop = true;
    }
    void Start()
    {
        GameObject gameManagement = GameObject.Find("GameManagement");
        GameObject board = GameObject.Find("Board");
        killSource = board.GetComponent<AudioSource>();
        processCollider = GetComponent<BoxCollider>();
        gameController = gameManagement.GetComponent<GameController>();
        light_ = GetComponentInChildren<Light>();
        TestDummyStart();
        currentInstruction = instructions.First;
        blinkAnimationCurve = gameController.blinkAnimationCurve;
        nextPosition = transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        timer = (float) gameController.timer;
        rate = (float) gameController.clock_rate;
        t = 1 - (rate - timer) / rate;
            light_.intensity = blinkAnimationCurve.Evaluate(t);
        if (currentInstruction != null){
            Instruction curr = currentInstruction.Value;
            if (!curr.isDone){
                curr.Execute();
            }
            else{
                currentInstruction = currentInstruction.Next;
            }
        }
        else if (loop){
            ResetInstructions();
            currentInstruction = instructions.First;
        }
    }

    // void OnTriggerExit(Collider other){
    //     Kill();
    // }

    public float getTime(){
        return t;
    }
}
