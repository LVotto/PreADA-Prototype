using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoldProcessBehaviour : MonoBehaviour {
    public TimeController timeController;

    void FixedUpdate() {
        if (timeController.Timer == 0) {
            //GameObject processObj = Instantiate(processPrefab, transform.position, transform.rotation);
            //processObj.transform.parent = transform.parent;
            //Destroy(gameObject);
        }
    }
}
