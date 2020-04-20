using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInstruction {
    Vector2 Direction { get; }
    Material Material { get; }
    int Type { get; set; }
    string Name { get; }
    Program Program { get; set; }

    void Execute();
    void Execute(ProcessBehaviour process);
}
