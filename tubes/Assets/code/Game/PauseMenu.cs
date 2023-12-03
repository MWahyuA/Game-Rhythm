using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public bool pause;
    public static PauseMenu instance;
    public string SceneName;
    // Start is called before the first frame update

    void Start()
    {
        instance = this;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }

    public void Home()
    {
        Time.timeScale = 1f;
        if(SceneName == "Game")
        {
            GameManager.instance.ResetScore();
        } else if(SceneName == "GameFancy")
        {
            GameManagerFancy.instance.ResetScore();
        } else if(SceneName == "Gamebmth")
        {
            GameManagerbmth.instance.ResetScore();
        } else if(SceneName == "GameGundul")
        {
            GameManagerGundul.instance.ResetScore();
        } else if(SceneName == "GameIndo")
        {
            GameManagerIndo.instance.ResetScore();
        } else if(SceneName == "GameKurenai")
        {
            GameManagerKurenai.instance.ResetScore();
        } else if(SceneName == "GamePolines")
        {
            GameManagerPolines.instance.ResetScore();
        } else if(SceneName == "GameSeven")
        {
            GameManagerSeven.instance.ResetScore();
        } else if(SceneName == "GameSipatokaan")
        {
            GameManagerSipatokaan.instance.ResetScore();
        } else if(SceneName == "GameStyle")
        {
            GameManagerStyle.instance.ResetScore();
        }
        SceneManager.LoadScene("music_menu");
    }
}
