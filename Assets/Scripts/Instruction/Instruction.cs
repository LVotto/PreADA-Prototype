using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Instruction : IInstruction {
    public float t = 0;
    public ProcessBehaviour processBehaviour;
    public GameObject process;
    public bool isDone;
    public bool hasStarted;
    public GameController gameController;
    public abstract void Execute();
    public void PreUpdate() {
        t = processBehaviour.getTime();
    }

    protected int type = InstructionType.Void;

    public Vector2 Direction { get; protected set; }
    public Material Material { get; protected set; }
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

    protected void LoadMaterial() {
        string source;
        InstructionType.InstructionTypeMaterialMap.TryGetValue(Type, out source);
        if (source != null) {
            Material = Resources.Load<Material>(source);
        }
    }
}
