using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramBuilderBehaviour : MonoBehaviour {
    public GameObject ProgramInstructionPrefab;

    Program program;

    void Start() {
        program = new Program();
    }

    public void AddInstruction(IInstruction instruction) {
        int offsetY = 180;
        program.AddInstruction(instruction);
        GameObject programInstruction = Instantiate(ProgramInstructionPrefab, transform.position, Quaternion.identity);
        programInstruction.transform.SetParent(transform, false);
        programInstruction.transform.localPosition = new Vector3(-702, offsetY - program.Instructions.Count * 30, 0);
    }
}
