using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject relativeDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            relativeDoor.GetComponent<Animator>().SetTrigger("DoorOpen");
            if(relativeDoor.GetComponent<BoxCollider>() != null)
            {
                relativeDoor.GetComponent<BoxCollider>().enabled = false;
            }
            
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            relativeDoor.GetComponent<Animator>().SetTrigger("DoorClose");
            if (relativeDoor.GetComponent<BoxCollider>() != null)
            {
                relativeDoor.GetComponent<BoxCollider>().enabled = true;
            }
        }
        if(other.tag == "Robot")
        {
           other.GetComponent<HelperBot>().gameObject.SetActive(false);
        }
    }
}
