using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultFancy : MonoBehaviour
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
        GameObject go = GameObject.Find("GameManagerFancy");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManagerFancy gm = go.GetComponent<GameManagerFancy>();

        scoreText.text = gm.currentScoreFancy.ToString();
        badText.text = gm.badFancy.ToString();
        poorText.text = gm.poorFancy.ToString();
        goodText.text = gm.goodFancy.ToString();
        greatText.text = gm.greatFancy.ToString();
        combo.text = gm.HighComboFancy.ToString();
        akurasiText.text = gm.akurasiFancy.ToString()+"%";
        float akurasi = gm.akurasiFancy;
        int score = gm.currentScoreFancy;
        int healthFancy = gm.healthFancy;

        if(akurasi < 60 || healthFancy == 0)
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
            GameManagerFancy.instance.updateHighScoreFancy();
               if (!Happy.isPlaying)
            {

                Happy.Play();
            }
        }

        if(score > 30000)
        {
            rank.sprite = splus;
        } else if(score > 25000)
        {
            rank.sprite = s;
        } else if(score > 20000)
        {
            rank.sprite = a;
        }else if(score > 15000)
        {
            rank.sprite = b;
        } else if(score > 10000)
        {
            rank.sprite = c;
        }else
        {
            rank.sprite = f;
        }

    }
}
