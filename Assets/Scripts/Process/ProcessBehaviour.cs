using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessBehaviour : MonoBehaviour {
    Collider processCollider;
    Light lightComponent;
    TimeController timeController;

    public AnimationCurve moveAnimationCurve;
    public AnimationCurve blinkAnimationCurve;

    GameController gameController;
    float timer;
    float rate;
    //float t;
    LinkedList<Instruction> instructions = new LinkedList<Instruction>();
    LinkedListNode<Instruction> currentInstruction;
    bool loop = true;
    AudioSource killSource;
    public GameObject dyingLightPrefab;
    public Vector3 nextPosition;
    public List<Vector3> directions;

    public Program Program { get; set; }

    public Vector2 relativeCoordinates() {
        Vector2 pos2d = new Vector2(transform.position.x, transform.position.y);
        pos2d += new Vector2(gameController.origin.x, gameController.origin.y);
        return pos2d;
    }

    public Vector2Int boardCoordinates() {
        Vector2 pos2d = relativeCoordinates();
        pos2d = Vector2Int.zero; //
        return Vector2Int.zero;
    }

    public void Kill() {
        Vector3 dyingPosition = Vector3.ProjectOnPlane(transform.position, Vector3.back) + 1.5f * Vector3.forward;
        GameObject dyingLightObj = Instantiate(dyingLightPrefab, dyingPosition, Quaternion.identity);
        killSource.Play();
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    public void LoadMoveInstructions(List<Vector3> dirs) {
        instructions = new LinkedList<Instruction>();

        foreach (Vector3 v in dirs) {
            MoveInstruction instr = new MoveInstruction(gameController,
                                                        this.gameObject,
                                                        v);
            instructions.AddLast(instr);
        }
        currentInstruction = instructions.First;
    }

    void ResetInstructions() {
        LinkedListNode<Instruction> ci = instructions.First;
        while (ci != null) {
            Instruction c = ci.Value;
            c.isDone = false;
            c.hasStarted = false;
            ci = ci.Next;
        }
    }

    void TestDummyStart(List<Vector3> dirs) {
        LoadMoveInstructions(dirs);
        loop = true;
    }
    void Awake() {
        GameObject gameManagement = GameObject.Find("GameManagement");
        GameObject board = GameObject.Find("Board");
        GameObject processes = GameObject.Find("Processes");
        killSource = board.GetComponent<AudioSource>();
        processCollider = GetComponent<BoxCollider>();
        gameController = gameManagement.GetComponent<GameController>();
        lightComponent = GetComponentInChildren<Light>();
        timeController = gameManagement.GetComponent<TimeController>();
        // if (directions.Count == 0){
        //     directions = new List<Vector3> { 
        //         Vector3.up, Vector3.left, Vector3.down
        //     };
        // }
        // TestDummyStart(directions);

        currentInstruction = instructions.First;
        blinkAnimationCurve = gameController.blinkAnimationCurve;
        nextPosition = transform.position;
    }

    void FixedUpdate() {
        timer = timeController.Timer;
        rate = timeController.clockRate;
        float delta = 1 - (rate - timer) / rate;
        lightComponent.intensity = blinkAnimationCurve.Evaluate(delta);
        //if (currentInstruction != null) {
        //    Instruction curr = currentInstruction.Value;
        //    if (!curr.isDone) {
        //        curr.Execute();
        //    } else {
        //        currentInstruction = currentInstruction.Next;
        //    }
        //} else if (loop) {
        //    ResetInstructions();
        //    currentInstruction = instructions.First;
        //}
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent(out ProcessBehaviour pb)) {
            pb.Kill();
            Kill();
        }
        // Debug.Log("EXIT");
    }
    public float getTime() {
        return 10;
    }
}
