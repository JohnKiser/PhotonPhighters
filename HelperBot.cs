using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperBot : MonoBehaviour
{
    public GameObject Player;
    public float movementSpeed = 1;
    public float approachDistance = 4.0f;
    public AudioClip[] talk;

    void Update()
    {
        //Follows the player at a distance equal to the approachDistance
        Vector3 position = transform.position;
        float distanceToPlayer = Vector3.Distance(position, Player.transform.position);
        transform.LookAt(Player.transform);
        if (distanceToPlayer > approachDistance && transform.position.y < -35)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
    }

    public void Talk()
    {
        
    }
}
