using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionContainer : MonoBehaviour {
    int fixedHeight = 2;
    Vector2 padding = new Vector2(2, 1);
    Vector2 initPosition;

    public GameObject BoardObject;
    public GameObject InstructionPrefab;

    void Start() {
        BoardCreator Board = BoardObject.GetComponent<BoardCreator>();
        initPosition = new Vector2(-Board.dimensions.x / 2 - Board.CellSize / 2, -Board.dimensions.y / 2 + Board.CellSize / 2);
        Vector2 scale = new Vector2(Board.dimensions.x - padding.x, fixedHeight);

        transform.position = new Vector3(initPosition.x + scale.x / 2, initPosition.y + padding.y, -1);
        transform.localScale = scale;

        int offsetX = 1;
        int[] instructionTypes = new int[] {
            InstructionType.Movement.Straight.Up,
            InstructionType.Movement.Straight.Right,
            InstructionType.Movement.Straight.Down,
            InstructionType.Movement.Straight.Left,
        };
        for (int i = 0; i < 4; i++) {
            GameObject instruction = Instantiate(
                InstructionPrefab,
                new Vector3(initPosition.x + i + InstructionPrefab.transform.localScale.x + i * offsetX, transform.position.y, 0),
                Quaternion.identity);
            InstructionBehaviour instructionBeahvior = instruction.GetComponent<InstructionBehaviour>();
            instructionBeahvior.Type = instructionTypes[i];
            instructionBeahvior.transform.parent = transform;
        }
    }
}
