using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionContainer : MonoBehaviour {
    public GameObject InstructionPrefab;

    void Start() {
        int offsetX = 100;
        int[] instructionTypes = new int[] {
            InstructionType.Movement.Straight.Up,
            InstructionType.Movement.Straight.Right,
            InstructionType.Movement.Straight.Down,
            InstructionType.Movement.Straight.Left,
        };
        for (int i = 0; i < 4; i++) {
            GameObject instruction = Instantiate(InstructionPrefab);
            InstructionBehaviour instructionBeahvior = instruction.GetComponent<InstructionBehaviour>();
            RectTransform rectTransform = (RectTransform)transform;
            instructionBeahvior.Type = instructionTypes[i];
            instructionBeahvior.transform.parent = transform;
            instructionBeahvior.transform.localPosition = new Vector3(rectTransform.rect.xMin + offsetX/2 + i * offsetX, 0, 0);
        }
    }
}
