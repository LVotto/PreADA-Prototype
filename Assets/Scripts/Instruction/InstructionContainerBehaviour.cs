using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionContainerBehaviour : MonoBehaviour {
    List<IInstruction> instructions;
    ProgramBuilderBehaviour programBuilder;

    public GameObject InstructionPlaceholderPrefab;
    public GameObject ProgramBuilderObject;

    void Start() {
        instructions = new List<IInstruction>() {
            new StraightMovementInstruction(InstructionType.Movement.Straight.Up),
            new StraightMovementInstruction(InstructionType.Movement.Straight.Right),
            new StraightMovementInstruction(InstructionType.Movement.Straight.Down),
            new StraightMovementInstruction(InstructionType.Movement.Straight.Left),
        };
        programBuilder = ProgramBuilderObject.GetComponent<ProgramBuilderBehaviour>();
        BuildInstructions();
    }

    void BuildInstructions() {
        int offsetX = 100;

        for (int i = 0; i < instructions.Count; i++) {
            GameObject instruction = Instantiate(InstructionPlaceholderPrefab);
            InstructionPlaceholderBehaviour instructionBehaviour = instruction.GetComponent<InstructionPlaceholderBehaviour>();
            RectTransform rectTransform = (RectTransform)transform;
            instructionBehaviour.Instruction = (Instruction)instructions[i];
            instructionBehaviour.transform.SetParent(transform, false);
            instructionBehaviour.transform.localPosition = new Vector3(rectTransform.rect.xMin + offsetX / 2 + i * offsetX, 0);
            instructionBehaviour.transform.localScale = new Vector3(100, 100, -1);
            instructionBehaviour.onSelect += onInstructionSelect;
        }
    }

    void onInstructionSelect(IInstruction instruction) {
        programBuilder.AddInstruction(instruction);
    }
}
