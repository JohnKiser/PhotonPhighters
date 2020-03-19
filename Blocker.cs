using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    public GameObject[] balls;
    private GameObject closestBall;

    // Update is called once per frame
    void Update()
    {
        balls = GameManager.gManager.balls;

        closestBall = FindClosestBall();

        if (balls.Length >= 1)
        {
            this.transform.LookAt(closestBall.transform.position);
        }
    }

    public GameObject FindClosestBall()
    {
        GameObject closest = null;

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject b in balls)
        {
            Vector3 diff = b.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = b;
                distance = curDistance;
            }
        }
        return closest;
    }
}
