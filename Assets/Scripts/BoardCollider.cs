using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if (other.gameObject.TryGetComponent(out ProcessBehaviour pb)){
            pb.Kill();
        }
        Debug.Log("EXIT");
    }
}
