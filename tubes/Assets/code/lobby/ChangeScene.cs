using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator animSlideScene;

    void Start(){
        Screen.SetResolution(1280, 720, true);
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(changeScene("music_menu"));
        }
    }
    IEnumerator changeScene(string nameScene)
    {
        animSlideScene.SetTrigger("SlideScene");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nameScene);
    }
}
