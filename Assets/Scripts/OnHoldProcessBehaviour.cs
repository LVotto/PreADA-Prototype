using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoldProcessBehaviour : MonoBehaviour
{
    public GameObject processPrefab;
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagement = GameObject.Find("GameManagement");
        gameController = gameManagement.GetComponent<GameController>();
    }

    void FixedUpdate(){
        if (gameController.getTimer() == 0){
            GameObject processObj = Instantiate(
                processPrefab, transform.position, transform.rotation
            );
            processObj.transform.parent = transform.parent;
            Destroy(gameObject);
        }
    }
}
