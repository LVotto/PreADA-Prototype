using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program {
    public LinkedList<IInstruction> Instructions { get; }
    public ProcessBehaviour Process { get; set; }

    public Program() {
        Instructions = new LinkedList<IInstruction>();
    }

    public Program(Program program) : this() {
        Process = program.Process;
        foreach (IInstruction instruction in program.Instructions) {
            instruction.Program = this;
            Instructions.AddLast(instruction);
        }
    }

    public void AddInstruction(IInstruction instruction) {
        Instructions.AddLast(instruction);
        instruction.Program = this;
    }
}
