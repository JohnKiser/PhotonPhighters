using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpTrig : MonoBehaviour
{
    public InfoDesk info;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            info.beingHelped = true;
            info.startHelp = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            info.startHelp = false;
            info.beingHelped = false;
            info.first = false;
            info.second = false;
            info.last = false;
        }
    }
}
