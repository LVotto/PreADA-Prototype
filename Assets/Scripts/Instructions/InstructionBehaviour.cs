using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionBehaviour : MonoBehaviour {
    StraightMovementInstruction instruction = new StraightMovementInstruction();
    MeshRenderer meshRenderer;

    public int Type {
        get => instruction.Type;
        set {
            instruction.Type = value;
            meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.material = instruction.Material;
        }
    }
}
