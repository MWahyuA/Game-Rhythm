using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultKurenai : MonoBehaviour
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
        GameObject go = GameObject.Find("GameManagerKurenai");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManagerKurenai gm = go.GetComponent<GameManagerKurenai>();

        scoreText.text = gm.currentScoreKurenai.ToString();
        badText.text = gm.badKurenai.ToString();
        poorText.text = gm.poorKurenai.ToString();
        goodText.text = gm.goodKurenai.ToString();
        greatText.text = gm.greatKurenai.ToString();
        combo.text = gm.HighComboKurenai.ToString();
        akurasiText.text = gm.akurasiKurenai.ToString()+"%";
        float akurasi = gm.akurasiKurenai;
        int score = gm.currentScoreKurenai;
        int healthKurenai = gm.healthKurenai;

        if(akurasi < 60 || healthKurenai == 0)
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
            GameManagerKurenai.instance.updateHighScoreKurenai();
            if (!Happy.isPlaying)
            {

                Happy.Play();
            }
        }

        if(score > 46000)
        {
            rank.sprite = splus;
        } else if(score > 42000)
        {
            rank.sprite = s;
        } else if(score > 38000)
        {
            rank.sprite = a;
        }else if(score > 34000)
        {
            rank.sprite = b;
        } else if(score > 30000)
        {
            rank.sprite = c;
        }else
        {
            rank.sprite = f;
        }

    }
}
