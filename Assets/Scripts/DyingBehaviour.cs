using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingBehaviour : MonoBehaviour
{
    // public GameObject processObj;
    public AnimationCurve animationCurve;
    float t;
    // Start is called before the first frame update
    void Awake()
    {
        t = 0f;
        // transform.position = processObj.transform.position + Vector3.forward * 1.5f;
        // transform.position += new Vector3(0, 0, -processObj.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        t += Time.deltaTime;
        Vector3 z = 10 * Vector3.back * animationCurve.Evaluate(t);
        transform.position = Vector3.ProjectOnPlane(transform.position, Vector3.back);
        transform.position += z;
        if (t > 1f) Destroy(gameObject);
    }
}
