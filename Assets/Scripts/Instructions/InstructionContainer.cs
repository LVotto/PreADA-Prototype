using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionContainer : MonoBehaviour {
    int[] instructionTypes = new int[] {
            InstructionType.Movement.Straight.Up,
            InstructionType.Movement.Straight.Right,
            InstructionType.Movement.Straight.Down,
            InstructionType.Movement.Straight.Left,
        };
    List<StraightMovementInstruction> instructions = new List<StraightMovementInstruction>();

    public GameObject InstructionPlaceholderPrefab;
    public ProgramBuilder ProgramBuilder;

    void Start() {
        BuildInstructions();
    }

    void BuildInstructions() {
        int offsetX = 100;

        for (int i = 0; i < 4; i++) {
            GameObject instruction = Instantiate(InstructionPlaceholderPrefab);
            InstructionBehaviour instructionBehaviour = instruction.GetComponent<InstructionBehaviour>();
            RectTransform rectTransform = (RectTransform)transform;
            instructionBehaviour.Type = instructionTypes[i];
            instructionBehaviour.transform.parent = transform;
            instructionBehaviour.transform.localPosition = new Vector3(rectTransform.rect.xMin + offsetX / 2 + i * offsetX, 0);
            instructionBehaviour.transform.localScale += new Vector3(0, 0, -1);
            instructionBehaviour.onSelect += onInstructionSelect;
            instructions.Add(instructionBehaviour.Instruction);
        }
    }

    void onInstructionSelect(int instructionType) {
        //ProgramBuilder.AddInstruction
    }
}
