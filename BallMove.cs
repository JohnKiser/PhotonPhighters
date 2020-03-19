using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody rig;
    public float minVelocity;
    public float maxVelocity;

    private Vector3 lastFrameVelocity;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    //gets the velocity of ball the frame before it hits also if it is moving too slowly it will add velocity to the ball
    void FixedUpdate()
    {
        lastFrameVelocity = rig.velocity;

        if ((this.lastFrameVelocity.z < minVelocity || this.lastFrameVelocity.z > minVelocity * -1) && (this.lastFrameVelocity.z < maxVelocity || this.lastFrameVelocity.z < maxVelocity * -1))
        {
            this.rig.AddForce(new Vector3(0, 0, this.rig.velocity.z));
        }

        if (this.transform.position.z >15 || this.transform.position.z < -15)
        {
            Destroy(this);
            GameManager.gManager.BallSpawn();
        }

    }

    //call bounce with the normal of what it collides with
    public void OnCollisionEnter(Collision collider)
    {
        Bounce(collider.contacts[0].normal, collider.relativeVelocity);
    }

    //calculate the direction and speed of the the ball bounce

    private void Bounce(Vector3 collisionNormal, Vector3 vel)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
        rig.velocity = direction * Mathf.Max(speed, minVelocity);
        rig.AddForce(vel);
    }
}
