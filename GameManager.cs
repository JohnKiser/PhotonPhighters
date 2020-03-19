using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager gManager;

    public int playerScore;
    public int oppScore;

    public GameObject easyBot;
    public GameObject hardBot;

    public Transform ballSpawner;
    public GameObject ball;
    public GameObject[] balls;

    public GameObject lBuckler;
    public GameObject rBuckler;
    public GameObject lKite;
    public GameObject rKite;

    public GameObject displayKiteR;
    public GameObject displayKiteL;
    public GameObject displayBucR;
    public GameObject displayBucL;

    public TextMeshProUGUI playerBucklerScore;
    public TextMeshProUGUI oppBucklerScore;
    public TextMeshProUGUI playerKiteScore;
    public TextMeshProUGUI oppKiteScore;

    public Canvas winCan;
    public Canvas loseCan;
    
    public TextMeshProUGUI win;
    public TextMeshProUGUI lose;

    public GameObject ray;

    public GameObject playerCoralF;
    public GameObject playerCoralB;
    public GameObject pGoal;
    public GameObject oGoal;

    public Button wR;
    public Button wQ;
    public Button lR;
    public Button lQ;

    public float timer;
    public bool timerCount;



    // Start is called before the first frame update
    void Start()
    {
        gManager = this;
        lKite.SetActive(false);
        rKite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");

        if (OVRInput.Get(OVRInput.RawButton.X) && OVRInput.Get(OVRInput.RawButton.Y) && OVRInput.Get(OVRInput.RawButton.A) && OVRInput.Get(OVRInput.RawButton.B))
        {
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }

        if(easyBot.activeInHierarchy && playerScore >= 5)
        {
            hardBot.SetActive(true);
            SecondRound();
            
        }

        if(hardBot.activeInHierarchy && playerScore >= 11)
        {
            Win();
        }

        //counts down timer and displays time left
        if (timerCount)
        {
            win.text = "WINNER! \n Next round starting in: \n" + timer.ToString();
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                winCan.gameObject.SetActive(false);
                timerCount = false;
                BallSpawn();
            }
        }

        if(oppScore >= 11)
        {
            Lost();
        }

    }

    //called when the player wins
    public void Win()
    {
        ray.GetComponent<LineRenderer>().enabled = true;
        winCan.gameObject.SetActive(true);
        win.text = "WINNER \n You're on the team!";
    }

    //called when the player looses
    public void Lost()
    {
        ray.GetComponent<LineRenderer>().enabled = true;
        oGoal.SetActive(false);
        pGoal.SetActive(false);
        loseCan.gameObject.SetActive(true);
        foreach (GameObject b in balls)
        {
            Destroy(b);
        }
    }

    //called when the player beats the easy bot
    public void SecondRound()
    {
        easyBot.SetActive(false);
        playerScore = 0;
        oppScore = 0;
        timerCount = true;
        timer = 5;
        winCan.gameObject.SetActive(true);
        wR.gameObject.SetActive(false);
        wQ.gameObject.SetActive(false);

        

        foreach (GameObject b in balls)
        {
            Destroy(b);
        }

    }

    public void GameStart(Collider other)
    {
        if (other.tag == "Player")
        {
            playerCoralF.SetActive(true);
            playerCoralB.SetActive(true);
            pGoal.SetActive(true);
            oGoal.SetActive(true);
            BallSpawn();
            
        }
    }

    public void BallSpawn()
    {
        GameObject ballControl;
        ballControl = Instantiate(ball, ballSpawner.position, ballSpawner.rotation);
        ballControl.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.back * 10);
    }

    public void SwapShields(string tag)
    {
        if(tag == "Left")
        {
            if (lBuckler.activeInHierarchy)
            {
                lBuckler.SetActive(false);
                lKite.SetActive(true);
                displayBucL.SetActive(true);
                displayKiteL.SetActive(false);
            }
            else if (lKite.activeInHierarchy)
            {
                lBuckler.SetActive(true);
                lKite.SetActive(false);
                displayBucL.SetActive(false);
                displayKiteL.SetActive(true);
            }
        }else if(tag == "Right")
        {
            if (rBuckler.activeInHierarchy)
            {
                rBuckler.SetActive(false);
                rKite.SetActive(true);
                displayBucR.SetActive(true);
                displayKiteR.SetActive(false);
            }
            else if (rKite.activeInHierarchy)
            {
                rBuckler.SetActive(true);
                rKite.SetActive(false);
                displayBucR.SetActive(false);
                displayKiteR.SetActive(true);
            }
        }
        

    }

    public void UpdateScore(string goal)
    {
        if(goal == "PlayerGoal")
        {
         
            oppScore += 1;

            oppBucklerScore.text = oppScore.ToString();

            oppKiteScore.text = oppScore.ToString();

        }
        else if(goal == "OpponentGoal")
        {
        
            playerScore += 1;

            playerBucklerScore.text = playerScore.ToString();
            
            playerKiteScore.text = playerScore.ToString();
            
        }

        BallSpawn();
    }
}
