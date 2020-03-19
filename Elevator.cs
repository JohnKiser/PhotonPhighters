using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public GameObject elevator;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (elevator.transform.position.y < -30)
            {
                elevator.GetComponent<Animator>().SetTrigger("Up");
            }
            else if (elevator.transform.position.y > -30)
            {
                elevator.GetComponent<Animator>().SetTrigger("Down");
            }

        }
    }
}
