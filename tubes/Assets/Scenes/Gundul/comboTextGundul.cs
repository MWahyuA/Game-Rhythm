using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comboTextGundul : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("GameManagerGundul");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManagerGundul gm = go.GetComponent<GameManagerGundul>();

        GetComponent<Text>().text = "Combo " + gm.comboGundul+"x";
    }
}
