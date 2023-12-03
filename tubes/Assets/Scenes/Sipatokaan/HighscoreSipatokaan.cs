using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreSipatokaan: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("GameManagerSipatokaan");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManagerSipatokaan gm = go.GetComponent<GameManagerSipatokaan>();

        GetComponent<Text>().text = "" + gm.HighScoreSipatokaan;
    }
}
