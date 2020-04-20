using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessBehaviour : MonoBehaviour {
    Light lightComponent;
    TimeController timeController;
    LinkedListNode<IInstruction> currentInstructionNode;

    public AnimationCurve moveAnimationCurve;
    public AnimationCurve blinkAnimationCurve;
    public AudioSource KillSource;
    public GameObject DyingLightPrefab;
    public Vector3 nextPosition;

    public Program Program { get; set; }
    public Vector2 LocalPosition {
        get => gameObject.transform.localPosition;
        set { transform.localPosition = value; }
    }

    public void Kill() {
        Vector3 dyingPosition = Vector3.ProjectOnPlane(transform.position, Vector3.back) + 1.5f * Vector3.forward;
        Instantiate(DyingLightPrefab, dyingPosition, Quaternion.identity);
        KillSource.Play();
        Destroy(gameObject);
    }

    void Start() {
        GameObject gameManagement = GameObject.Find("GameManagement");
        lightComponent = GetComponentInChildren<Light>();
        timeController = gameManagement.GetComponent<TimeController>();

        currentInstructionNode = Program.Instructions.First;
    }

    void FixedUpdate() {
        Animate();
        ExecuteInstruction();
    }

    void Animate() {
        float timer = timeController.Timer;
        float rate = timeController.clockRate;
        float delta = 1 - (rate - timer) / rate;
        lightComponent.intensity = blinkAnimationCurve.Evaluate(delta);
    }

    void ExecuteInstruction() {
        IInstruction currentInstruction = currentInstructionNode.Value;
        if (timeController.isCycleStart()) {
            currentInstruction.Execute(this);
            currentInstructionNode = currentInstructionNode.Next;
            if (currentInstructionNode == null)
                currentInstructionNode = Program.Instructions.First;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent(out ProcessBehaviour pb)) {
            pb.Kill();
            Kill();
        }
    }

    public float getTime() {
        return 10;
    }
}
