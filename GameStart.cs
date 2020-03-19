using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    //Starts the game when the player enters the arena
    public void OnTriggerEnter(Collider other)
    {
        GameManager.gManager.GameStart(other);
        SceneSaver.ss.AddDrums();
        this.gameObject.SetActive(false);
    }
}
