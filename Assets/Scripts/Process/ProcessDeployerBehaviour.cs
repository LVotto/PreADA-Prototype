using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessDeployerBehaviour : MonoBehaviour {
    Program program;

    public GameObject ProcessPrefab;
    public GameObject Board;

    public Program Program {
        get => program;
        set {
            program = value;
            enabled = value != null;
            GameObject processPlaceholder = transform.GetChild(0).gameObject;
            processPlaceholder.SetActive(value != null);
        }
    }

    void FixedUpdate() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject process = Instantiate(ProcessPrefab, transform.position, transform.rotation);
            process.transform.position += Vector3.back;
            process.transform.parent = Board.transform;

            ProcessBehaviour processBehaviour = process.GetComponent<ProcessBehaviour>();
            Program programCopy = new Program(program) { Process = processBehaviour };
            processBehaviour.Program = programCopy;
        }
        if (Input.GetMouseButtonDown(1)) {
            Program = null;
        }
    }
}
