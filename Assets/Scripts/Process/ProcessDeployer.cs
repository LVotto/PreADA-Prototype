using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessDeployer : MonoBehaviour {
    Program program;
    TimeController timeController;

    public GameObject ProcessPrefab;
    public GameObject GameManagement;
    public Program Program {
        get => program;
        set {
            program = value;
            enabled = value != null;
        }
    }

    void Start() {
        GameObject gameManagement = GameObject.Find("GameManagement");
        timeController = gameManagement.GetComponent<TimeController>();
    }

    void FixedUpdate() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject process = Instantiate(ProcessPrefab);
            process.transform.position += Vector3.back;
            process.transform.parent = transform.parent;
        }
    }
}
