using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    public GameObject processPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            GameObject processObj = Instantiate(processPrefab, transform.position, transform.rotation);
            processObj.transform.parent = transform.parent;
        }
    }
}
