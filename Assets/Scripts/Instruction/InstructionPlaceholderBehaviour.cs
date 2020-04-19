using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionPlaceholderBehaviour : MonoBehaviour {
    MeshRenderer meshRenderer;
    Instruction instruction;

    public Instruction Instruction {
        get => instruction;
        set {
            instruction = value;
            meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.material = value.Material;
        }
    }
    public delegate void OnSelectEvent(IInstruction instruction);
    public OnSelectEvent onSelect;

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            onSelect(Instruction);
        }
    }
}
