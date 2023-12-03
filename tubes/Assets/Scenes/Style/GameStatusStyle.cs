using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStatusStyle : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public bool play;
    public BeatScrollerStyle theBS;
    public bool pause;
    public string sceneResult;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("PauseButton");

        PauseMenu pm = go.GetComponent<PauseMenu>();

        pause = pm.pause;

        if (!startPlaying && !play)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                theMusic.Play();
                play = true;
            }

        }

        if(!startPlaying && play)
        {
            startPlaying = true;
            theMusic.Play();
        }

        if (pause)
        {
            theMusic.Pause();
            startPlaying = false;
        }

        if (!theMusic.isPlaying && startPlaying)
        {
           SceneManager.LoadScene(sceneResult);
        }
    }
}
