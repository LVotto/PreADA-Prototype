using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovementInstruction : Instruction {
    public static Dictionary<int, Vector2> StraightMovementMap = new Dictionary<int, Vector2>() {
        { InstructionType.Movement.Straight.Up, new Vector2(0, 1) },
        { InstructionType.Movement.Straight.Right, new Vector2(1, 0) },
        { InstructionType.Movement.Straight.Down, new Vector2(0, -1) },
        { InstructionType.Movement.Straight.Left, new Vector2(0, -1) },
    };

    public StraightMovementInstruction() : this(InstructionType.Void) { }

    public StraightMovementInstruction(int type) {
        if (type != InstructionType.Void) {
            Direction = StraightMovementMap[type];
            Type = type;
            LoadMaterial();
        }
    }

    public override void Execute() {
        throw new System.NotImplementedException();
    }
}
