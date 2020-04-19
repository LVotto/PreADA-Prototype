using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program {
    public List<IInstruction> Instructions { get; }

    public Program() {
        Instructions = new List<IInstruction>();
    }

    public void AddInstruction(IInstruction instruction) {
        Instructions.Add(instruction);
    }
}
