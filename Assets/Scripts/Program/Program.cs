using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program {
    public LinkedList<IInstruction> Instructions { get; }
    public ProcessBehaviour Process { get; set; }

    public Program() {
        Instructions = new LinkedList<IInstruction>();
    }

    public void AddInstruction(IInstruction instruction) {
        Instructions.AddLast(instruction);
        instruction.Program = this;
    }
}
