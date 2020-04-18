using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnHoldProcessBehaviour : MonoBehaviour
{
    public GameObject processPrefab;
    TimeController timeController;
    public List<Vector3> directions;
    // Start is called before the first frame update
    GameObject processes;
    void Start()
    {
        GameObject gameManagement = GameObject.Find("GameManagement");
        timeController = gameManagement.GetComponent<TimeController>();
        
        processes = GameObject.Find("Processes");
    }

    void FixedUpdate(){
        if (timeController.Timer == 0){
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
