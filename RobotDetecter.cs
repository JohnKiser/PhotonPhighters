using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDetecter : MonoBehaviour
{
    public GameObject robot;
    RaycastHit hit;
    public Animator roboAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward) * 25;

        Physics.Raycast(transform.position, fwd, out hit);        

        if (hit.collider.name == robot.name)
        {
            roboAnim.SetTrigger("SpinTrig");
        }

    }
}
