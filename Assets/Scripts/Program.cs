using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program {
    List<StraightMovementInstruction> instructions;

    public void AddInstruction(StraightMovementInstruction instruction) {
        instructions.Add(instruction);
    }
}
