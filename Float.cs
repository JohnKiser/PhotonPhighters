using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public float bouncyness = 3;
    public float size = 3;
    public float speed;
    public float yPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
            this.transform.position = new Vector3(this.transform.position.x ,Mathf.Sin(Time.time*speed*Mathf.PI /bouncyness)/size + yPos, this.transform.position.z);

    }
}
