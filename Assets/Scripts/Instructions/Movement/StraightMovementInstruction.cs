using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovementInstruction {
    private int type = InstructionType.Void;
    public Vector2 Direction { get; }
    public Material Material { get; private set; }
    public int Type {
        get => type;
        set {
            type = value;
            LoadMaterial();
        }
    }
    public string Name {
        get => InstructionType.InstructionTypeNameMap[Type];
    }

    public static Dictionary<int, Vector2> StraightMovementMap = new Dictionary<int, Vector2>() {
        { InstructionType.Movement.Straight.Up, new Vector2(0, 1) },
        { InstructionType.Movement.Straight.Right, new Vector2(1, 0) },
        { InstructionType.Movement.Straight.Down, new Vector2(0, -1) },
        { InstructionType.Movement.Straight.Left, new Vector2(0, -1) },
    };

    public StraightMovementInstruction() : this(InstructionType.Void) { }

    public StraightMovementInstruction(int type) {
        Vector2 direction;
        StraightMovementMap.TryGetValue(type, out direction);
        Direction = direction;
        if (type != InstructionType.Void) {
            Type = type;
            LoadMaterial();
        }
    }

    private void LoadMaterial() {
        string source;
        InstructionType.InstructionTypeMaterialMap.TryGetValue(Type, out source);
        if (source != null) {
            Material = Resources.Load<Material>(source);
        }
    }
}
