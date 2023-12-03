using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DifferentClick : MonoBehaviour, IPointerClickHandler
{
    public AudioSource BGM;
    public string sceneName;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!BGM.isPlaying)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                BGM.Play();
            }
        }
        else
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                BGM.Stop();
            }
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if(sceneName == "Game")
            {
                GameManager.instance.ResetScore();
                SceneManager.LoadScene(sceneName);
            } else if(sceneName == "GameFancy")
            {
                GameManagerFancy.instance.ResetScore();
                SceneManager.LoadScene(sceneName);
            } else if(sceneName == "GameIndo")
            {
                GameManagerIndo.instance.ResetScore();
                SceneManager.LoadScene(sceneName);
            }
            else if (sceneName == "GameSeven")
            {
                GameManagerSeven.instance.ResetScore();
                SceneManager.LoadScene(sceneName);
            }
            else if (sceneName == "GameStyle")
            {
                GameManagerStyle.instance.ResetScore();
                SceneManager.LoadScene(sceneName);
            }
             else if (sceneName == "GamePolines")
            {
                GameManagerPolines.instance.ResetScore();
                SceneManager.LoadScene(sceneName);
            }
            else if (sceneName == "GameSipatokaan")
            {
                GameManagerSipatokaan.instance.ResetScore();
                SceneManager.LoadScene(sceneName);
            }
             else if (sceneName == "GameGundul")
            {
                GameManagerGundul.instance.ResetScore();
                SceneManager.LoadScene(sceneName);
            }
            else if (sceneName == "GameKurenai")
            {
                GameManagerKurenai.instance.ResetScore();
                SceneManager.LoadScene(sceneName);
            }
            else if (sceneName == "Gamebmth")
            {
                GameManagerbmth.instance.ResetScore();
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
