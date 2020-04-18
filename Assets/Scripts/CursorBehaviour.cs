using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    public GameObject onHoldProcessPrefab;
    GameController gameController;
    Vector3 position;
    ProgramBehaviour programBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagement = GameObject.Find("GameManagement");
        gameController = gameManagement.GetComponent<GameController>();
        GameObject program = GameObject.Find("Program");
        programBehaviour = program.GetComponent<ProgramBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            position = transform.position;
            GameObject onHoldProcessObj = Instantiate(
                onHoldProcessPrefab, position, transform.rotation
            );
            OnHoldProcessBehaviour oHPBehaviour = onHoldProcessObj.GetComponent<OnHoldProcessBehaviour>();
            onHoldProcessObj.transform.position += Vector3.back;
            onHoldProcessObj.transform.parent = transform.parent;
            oHPBehaviour.directions = programBehaviour.directions;
        }
        if(Input.GetMouseButtonDown(1)){
            Debug.Log(
                Camera.main.ScreenToWorldPoint(Input.mousePosition)
            );
        }
    }
}
