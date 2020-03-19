using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSwapper : MonoBehaviour
{
    public float swapTimer;
    public float countdown;

    public void Update()
    {
        countdown += Time.deltaTime;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(countdown >= swapTimer)
        {
            GameManager.gManager.SwapShields(other.tag);
        }
        
    }

}
