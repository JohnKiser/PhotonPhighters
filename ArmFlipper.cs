using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmFlipper : MonoBehaviour
{
    public float rotateTime = 15.0f;
    public float rotateTimeRandom = 5.0f;

    private Vector3 currentAngle;
    private float t = 0.0f;
    public float minimum = 0.0f;
    public float maximum = 180f;

    public bool left;

    bool flipped = false;
    private float timer;

    private GameObject[] balls;
    private GameObject closestBall;

    private void Start()
    {
        //setup initial angle
        currentAngle = transform.eulerAngles;

        //set the timer for rotation
        timer = rotateTime + Random.Range(-rotateTimeRandom, rotateTimeRandom);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        balls = GameManager.gManager.balls;

        if(balls.Length >= 1)
        {
            closestBall = FindClosestBall();
            if (closestBall.transform.position.x < -0.5 && !left && closestBall.transform.position.y < .5)
            {
                this.transform.position = new Vector3(closestBall.transform.position.x, closestBall.transform.position.y, this.transform.position.z);
            }
            if (closestBall.transform.position.x >= 0 && left && closestBall.transform.position.y < .5)
            {
                this.transform.position = new Vector3(closestBall.transform.position.x, closestBall.transform.position.y, this.transform.position.z);
            }
        }


        timer -= Time.deltaTime;

        //float flip = Random.Range(0, 1000);
        if (timer <= 0.0f)
        {
            flipped = !flipped;
            timer = rotateTime + Random.Range(-rotateTimeRandom, rotateTimeRandom);
        }
        if (flipped && t < 1.0f)
        {
            // animate the position of the game object...
            transform.eulerAngles = new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0);

            // .. and increase the t interpolater
            t += 0.5f * Time.deltaTime;

            // now check if the interpolator has reached 1.0
            // and swap maximum and minimum so game object moves
            // in the opposite direction.
            if (t > 1.0f)
            {
                float temp = maximum;
                maximum = minimum;
                minimum = temp;
                t = 0.0f;
                flipped = !flipped;
            }
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
