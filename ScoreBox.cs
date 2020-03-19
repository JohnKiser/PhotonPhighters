using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        print("hit");
        if (other.tag == "Ball")
        {
            print("ball hit");
            GameManager.gManager.UpdateScore(this.name);
            Destroy(other.gameObject);
        }
    }
}
