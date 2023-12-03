using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSeven : MonoBehaviour
{
    public Text scoreText;
    public Text badText;
    public Text poorText;
    public Text goodText;
    public Text greatText;
    public Text akurasiText;
    public Text combo;
    public SpriteRenderer result;
    public Sprite pass;
    public Sprite fail;
    public SpriteRenderer rank;
    public Sprite f;
    public Sprite c;
    public Sprite b;
    public Sprite a;
    public Sprite s;
    public Sprite splus;
    public Animator animator;
    public AudioSource Happy;
    public AudioSource Sad;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("GameManagerSeven");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManagerSeven gm = go.GetComponent<GameManagerSeven>();

        scoreText.text = gm.currentScoreSeven.ToString();
        badText.text = gm.badSeven.ToString();
        poorText.text = gm.poorSeven.ToString();
        goodText.text = gm.goodSeven.ToString();
        greatText.text = gm.greatSeven.ToString();
        combo.text = gm.HighComboSeven.ToString();
        akurasiText.text = gm.akurasiSeven.ToString()+"%";
        float akurasi = gm.akurasiSeven;
        int score = gm.currentScoreSeven;
        int health = gm.healthSeven;

        if(akurasi < 60 || health == 0)
        {
            result.sprite = fail; 
            bool isMiss = true;
            animator.SetBool("isMiss", isMiss);
            if (!Sad.isPlaying)
            {

                Sad.Play();
            }

        }
        else
        {
            result.sprite = pass;
            bool isHappy = true;
            animator.SetBool("isHappy", isHappy);
            GameManagerSeven.instance.updateHighScoreSeven();
             if (!Happy.isPlaying)
            {

                Happy.Play();
            }
        }

        if(score > 33000)
        {
            rank.sprite = splus;
        } else if(score > 28000)
        {
            rank.sprite = s;
        } else if(score > 23000)
        {
            rank.sprite = a;
        }else if(score > 18000)
        {
            rank.sprite = b;
        } else if(score > 13000)
        {
            rank.sprite = c;
        }else
        {
            rank.sprite = f;
        }

    }
}
