using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoldProcessBehaviour : MonoBehaviour
{
    public GameObject processPrefab;
    GameController gameController;
    public List<Vector3> directions;
    // Start is called before the first frame update
    GameObject processes;
    void Start()
    {
        GameObject gameManagement = GameObject.Find("GameManagement");
        gameController = gameManagement.GetComponent<GameController>();
        
        processes = GameObject.Find("Processes");
    }

    void FixedUpdate(){
        if (gameController.getTimer() == 0){
            GameObject processObj = Instantiate(
                processPrefab, transform.position, transform.rotation
            );
            processObj.transform.parent = processes.transform;
            ProcessBehaviour processBehaviour = processObj.GetComponent<ProcessBehaviour>();
            processBehaviour.LoadMoveInstructions(directions);
            Destroy(gameObject);
        }
    }
}
