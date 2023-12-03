using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
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
    public SpriteRenderer character;
    public Sprite characterSad;
    public Sprite characterHappy;
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
        GameObject go = GameObject.Find("GameManager");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManager gm = go.GetComponent<GameManager>();

        scoreText.text = gm.currentScore.ToString();
        badText.text = gm.bad.ToString();
        poorText.text = gm.poor.ToString();
        goodText.text = gm.good.ToString();
        greatText.text = gm.great.ToString();
        combo.text = gm.HighCombo.ToString();
        akurasiText.text = gm.akurasi.ToString()+"%";
        float akurasi = gm.akurasi;
        int score = gm.currentScore;
        int health = gm.health;

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
            GameManager.instance.updateHighScore();
                if (!Happy.isPlaying)
            {

                Happy.Play();
            }
        }

        if(score > 35000)
        {
            rank.sprite = splus;
        } else if(score > 30000)
        {
            rank.sprite = s;
        } else if(score > 24000)
        {
            rank.sprite = a;
        }else if(score > 19000)
        {
            rank.sprite = b;
        } else if(score > 15000)
        {
            rank.sprite = c;
        }else
        {
            rank.sprite = f;
        }

    }
}
