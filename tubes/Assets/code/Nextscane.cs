using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextscane : MonoBehaviour
{
    public Animator animSlideScene;
    // Start is called before the first frame update
    void Start()
    {
        
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

