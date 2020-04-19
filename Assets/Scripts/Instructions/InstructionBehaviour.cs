using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionBehaviour : MonoBehaviour {
    MeshRenderer meshRenderer;

    public StraightMovementInstruction Instruction { get; private set; } = new StraightMovementInstruction();
    public delegate void OnSelectEvent(int type);
    public OnSelectEvent onSelect;

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log(Instruction.Name);
            onSelect(Instruction.Type);
        }
    }

    public int Type {
        get => Instruction.Type;
        set {
            Instruction.Type = value;
            meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.material = Instruction.Material;
        }
    }
}
