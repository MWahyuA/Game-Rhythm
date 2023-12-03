using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreIndo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("GameManagerIndo");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManagerIndo gm = go.GetComponent<GameManagerIndo>();

        GetComponent<Text>().text = "" + gm.HighScoreIndo;
    }
}
