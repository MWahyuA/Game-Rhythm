using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscorePolines : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("GameManagerPolines");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManagerPolines gm = go.GetComponent<GameManagerPolines>();

        GetComponent<Text>().text = "" + gm.HighScorePolines;
    }
}
