using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessBehaviour : MonoBehaviour {
    Light lightComponent;
    TimeController timeController;
    LinkedListNode<IInstruction> currentInstructionNode;
    GameObject processPlaceholder;
    GameObject processContainer;
    int offsetY = 100;

    public AnimationCurve moveAnimationCurve;
    public AnimationCurve blinkAnimationCurve;
    public AudioSource KillSource;
    public GameObject DyingLightPrefab;
    public GameObject ProcessPlaceholderPrefab;
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
        Destroy(processPlaceholder);
    }

    void Start() {
        processContainer = GameObject.Find("ProcessContainer");
        GameObject gameManagement = GameObject.Find("GameManagement");
        timeController = gameManagement.GetComponent<TimeController>();
        lightComponent = GetComponentInChildren<Light>();

        currentInstructionNode = Program.Instructions.First;

        int index = processContainer.transform.childCount;
        processPlaceholder = Instantiate(ProcessPlaceholderPrefab);
        processPlaceholder.transform.SetParent(processContainer.transform, false);
        processPlaceholder.transform.localPosition += new Vector3(0, -(offsetY * index), 0);

        Text processPlaceholderText = processPlaceholder.GetComponent<Text>();
        processPlaceholderText.text = "P" + index;
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
