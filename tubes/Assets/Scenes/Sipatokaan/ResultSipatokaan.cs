using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSipatokaan : MonoBehaviour
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
        GameObject go = GameObject.Find("GameManagerSipatokaan");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManagerSipatokaan gm = go.GetComponent<GameManagerSipatokaan>();

        scoreText.text = gm.currentScoreSipatokaan.ToString();
        badText.text = gm.badSipatokaan.ToString();
        poorText.text = gm.poorSipatokaan.ToString();
        goodText.text = gm.goodSipatokaan.ToString();
        greatText.text = gm.greatSipatokaan.ToString();
        combo.text = gm.HighcomboSipatokaan.ToString();
        akurasiText.text = gm.akurasiSipatokaan.ToString()+"%";
        float akurasi = gm.akurasiSipatokaan;
        int score = gm.currentScoreSipatokaan;
        int health = gm.healthSipatokaan;

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
            GameManagerSipatokaan.instance.updateHighScoreSipatokaan();
             if (!Happy.isPlaying)
            {

                Happy.Play();
            }
        }

        if(score > 10000)
        {
            rank.sprite = splus;
        } else if(score > 8500)
        {
            rank.sprite = s;
        } else if(score > 7500)
        {
            rank.sprite = a;
        }else if(score > 6500)
        {
            rank.sprite = b;
        } else if(score > 5500)
        {
            rank.sprite = c;
        }else
        {
            rank.sprite = f;
        }

    }
}
