using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Instruction
{
    public float t = 0;
    public ProcessBehaviour processBehaviour;
    public GameObject process;
    public bool isDone;
    public bool hasStarted;
    public GameController gameController;
    public abstract void Execute();
    public void PreUpdate(){
        t = processBehaviour.getTime();
    }
}
