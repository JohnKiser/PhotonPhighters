using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoDesk : MonoBehaviour
{
    public bool startHelp = false;
    public bool beingHelped = false;
    public bool first = false;
    public bool second = false;
    public bool last = false;
    public TextMeshProUGUI helperText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beingHelped)
        {
            this.GetComponent<Float>().enabled = false;
            ActiveText();
            startHelp = !startHelp;
        }
        else
        {
            this.GetComponent<Float>().enabled = true;

        }

        if (!beingHelped)
        {
            helperText.text = "Need \n Help?";
        }

        if (OVRInput.Get(OVRInput.RawButton.A) && first && beingHelped)
        {
            second = true;
            ActiveText();
        }

        if (OVRInput.Get(OVRInput.RawButton.B) && second && last && helperText.text != "Need \n Help?")
        {
            beingHelped = !beingHelped;
            first = !first;
            second = !second;
            startHelp = !startHelp;
        }
    }

    public void ActiveText()
    {
        first = true;
        helperText.text = "Hello and welcome to the Cyan side locker room! If at any time you need to leave simply press the A, B, X, and Y buttons on your controller at the same time. \n \n Press A for more info.";

        if(first && second)
        {
            last = true;
            helperText.text = "When you enter the pink goal line upstairs the goalie guards will apear to keep you in place. You can move side to side but you cant leave the goal zone or you will be disqualified. \n Good luck and have fun! \n Press B to close.";
        }
    }

}
