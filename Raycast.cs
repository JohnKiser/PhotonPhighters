using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public LineRenderer line;
    public float width = 0.01f;
    public float length = 25f;
    public RaycastHit raycastHit;
    public SceneSaver manager;

    private void Start()
    {

        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };

        manager = SceneSaver.ss;

        if (line == null)
        {
            line = this.GetComponent<LineRenderer>();
        }

        
        line.SetPositions(initLaserPositions);
        line.startWidth = width;
        line.endWidth = width;
    }

    // Update is called once per frame
    void Update()
    {
        MakeRaycast(this.transform.position);
        if(manager == null)
        {
            manager = FindObjectOfType<SceneSaver>();
        }
    }

    public void MakeRaycast(Vector3 origin)
    {

        Ray ray = new Ray(origin, (this.transform.forward));
        
        Vector3 endPosition = origin + (length * this.transform.forward);

        if (Physics.Raycast(ray, out raycastHit, length*2))
        {
            endPosition = raycastHit.point;

            if (raycastHit.transform.name == "Play" && OVRInput.Get(OVRInput.RawButton.A))
            {
                manager.GameStart();
            }

            if (raycastHit.transform.name == "Quit" && OVRInput.Get(OVRInput.RawButton.A))
            {
                manager.Quit();
            }

            if (raycastHit.transform.name == "Endless" && OVRInput.Get(OVRInput.RawButton.A))
            {
                manager.EndlessMode(OVRInput.RawButton.A);
            }

            if (raycastHit.transform.name == "Endless" && OVRInput.Get(OVRInput.RawButton.B))
            {
                manager.EndlessMode(OVRInput.RawButton.B);
            }

            if(raycastHit.transform.name == "Restart" && OVRInput.Get(OVRInput.RawButton.A))
            {
                manager.StartOver();
            }
        }

        line.SetPosition(0, origin);
        line.SetPosition(1, endPosition);
        
    }
}
