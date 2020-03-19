using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneSaver : MonoBehaviour
{
    public bool endless = false;
    public bool hardMode = false;
    public GameObject player;
    public static SceneSaver ss;

    public AudioMixerSnapshot chords;
    public AudioMixerSnapshot bass;
    public AudioMixerSnapshot drums;

    public AudioSource[] a;

    // Start is called before the first frame update
    void Start()
    {
        a = this.GetComponents<AudioSource>();
        ss = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.X) && OVRInput.Get(OVRInput.RawButton.Y) && OVRInput.Get(OVRInput.RawButton.A) && OVRInput.Get(OVRInput.RawButton.B))
        {
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    public void EndlessMode(OVRInput.RawButton button)
    {
        if(button == OVRInput.RawButton.A)
        {
            endless = true;
            player.GetComponent<OVRScreenFade>().FadeOut();
            SceneManager.LoadScene("Main");
            bass.TransitionTo(2);
        }
        else if(button == OVRInput.RawButton.B)
        {
            endless = true;
            hardMode = true;
            player.GetComponent<OVRScreenFade>().FadeOut();
            SceneManager.LoadScene("Main");
            bass.TransitionTo(2);
        }
    }

    public void GameStart()
    {
        player.GetComponent<OVRScreenFade>().FadeOut();
        SceneManager.LoadScene("Main");
        bass.TransitionTo(2);
    }

    public void Quit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void StartOver()
    {
        player.GetComponent<OVRScreenFade>().FadeOut();
        SceneManager.LoadScene("StartScene");
        chords.TransitionTo(1);
        foreach(AudioSource a in a)
        {
            Destroy(a);
        }
    }

    public void AddDrums()
    {
        drums.TransitionTo(1);
    }
}
