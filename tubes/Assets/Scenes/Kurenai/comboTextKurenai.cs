using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comboTextKurenai : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("GameManagerKurenai");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManagerKurenai gm = go.GetComponent<GameManagerKurenai>();

        GetComponent<Text>().text = "Combo " + gm.comboKurenai+"x";
    }
}
