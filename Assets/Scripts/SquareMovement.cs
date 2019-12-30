using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    float square_size = 1f; 
    public float debounce_rate = 60f;    
    float debounce = 0f;
    //float speed = 1f;
    Vector3 direction = Vector3.zero;
    Vector3 target = new Vector3(0, 0, 0);
    Vector3 start = new Vector3(0,0,0);
    public AnimationCurve ac;
    public GameObject light_go;
    Light lght;
    void move_to(Vector3 direction){
        transform.position = transform.position + direction;
    }

    void Start(){
        start = transform.position;
        target = transform.position;
        lght = light_go.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float ver_input = Input.GetAxis("Vertical");
        float hor_input = Input.GetAxis("Horizontal");
        Vector3 new_direction = new Vector3(0, 0, 0);
        if(ver_input == 0 ^ hor_input == 0){
            new_direction = new Vector3(hor_input, ver_input, 0);
        }

        if (debounce == 0 && new_direction.magnitude > 0){
            direction = new_direction;
            direction.Normalize();
            
            start = transform.position;
            target = transform.position + square_size * direction;
            debounce = debounce_rate;
        }

        if(debounce > 0){
            float t = (debounce_rate - debounce) / debounce_rate;
            Vector3 delta = (target - start) * ac.Evaluate(t);
            lght.intensity = ac.Evaluate(t);
            transform.position = start + delta;
            debounce += -1;
        }
    }
}
