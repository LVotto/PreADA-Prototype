using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInstruction : Instruction
{
    Vector3 start, stop;
    public Vector3 direction;
    AnimationCurve moveAnimationCurve;
    float stepSize;
    public MoveInstruction(GameController gameController,
                           GameObject process, Vector3 direction){
        isDone = false;
        hasStarted = false;
        this.process = process;
        this.direction = direction;
        this.gameController = gameController;
        processBehaviour = process.GetComponent<ProcessBehaviour>();
        start = process.transform.position;
        direction.Normalize();
        stop = start + direction;
        moveAnimationCurve = gameController.moveAnimationCurve;
        stepSize = gameController.cellSize;
    }

    public override void Execute(ProcessBehaviour process) { Execute(); }
    public override void Execute(){
        PreUpdate();
        processBehaviour.nextPosition = stop;
        if (!this.hasStarted){
            hasStarted = true;
            start = process.transform.position;
            direction.Normalize();
            stop = start + direction * stepSize;
        }
        process.transform.position = start + (stop - start) 
                                   * moveAnimationCurve.Evaluate(t);
        if (t == 1){
            isDone = true;
            hasStarted = false;
        }
    }
}
