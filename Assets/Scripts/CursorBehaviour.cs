using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    public GameObject onHoldProcessPrefab;
    GameController gameController;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagement = GameObject.Find("GameManagement");
        gameController = gameManagement.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            position = transform.position;
            GameObject onHoldProcessObj = Instantiate(
                onHoldProcessPrefab, position, transform.rotation
            );
            onHoldProcessObj.transform.position += Vector3.back;
            onHoldProcessObj.transform.parent = transform.parent;
        }
    }
}
