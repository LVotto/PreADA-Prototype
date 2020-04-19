using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgramBuilderBehaviour : MonoBehaviour {
    public GameObject ProgramInstructionPrefab;
    public GameObject CursorObject;
    public GameObject DeployButtonObject;

    Program program;

    void Start() {
        program = new Program();
    }

    public void AddInstruction(IInstruction instruction) {
        int offsetY = 180;
        program.AddInstruction(instruction);

        GameObject programInstruction = Instantiate(ProgramInstructionPrefab, transform.position, Quaternion.identity);
        programInstruction.transform.SetParent(transform, false);
        programInstruction.transform.localPosition = new Vector3(-702, offsetY - (program.Instructions.Count - 1) * 30, 0);

        Text programInstructionText = programInstruction.GetComponent<Text>();
        programInstructionText.text = instruction.Name;
    }

    public void OnDeployButtonClick() {
        ProcessDeployerBehaviour processDeployer = CursorObject.GetComponent<ProcessDeployerBehaviour>();
        processDeployer.Program = program;
        gameObject.SetActive(false);
    }
}
