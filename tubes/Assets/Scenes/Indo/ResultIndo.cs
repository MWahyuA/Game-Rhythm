using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultIndo : MonoBehaviour
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
        GameObject go = GameObject.Find("GameManagerIndo");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManagerIndo gm = go.GetComponent<GameManagerIndo>();

        scoreText.text = gm.currentScoreIndo.ToString();
        badText.text = gm.badIndo.ToString();
        poorText.text = gm.poorIndo.ToString();
        goodText.text = gm.goodIndo.ToString();
        greatText.text = gm.greatIndo.ToString();
        combo.text = gm.HighComboIndo.ToString();
        akurasiText.text = gm.akurasiIndo.ToString()+"%";
        float akurasi = gm.akurasiIndo;
        int score = gm.currentScoreIndo;
        int health = gm.healthIndo;

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
            GameManagerIndo.instance.updateHighScoreIndo();
            if (!Happy.isPlaying)
            {

                Happy.Play();
            }
        }

        if(score > 17500)
        {
            rank.sprite = splus;
        } else if(score > 15000)
        {
            rank.sprite = s;
        } else if(score > 12000)
        {
            rank.sprite = a;
        }else if(score > 9000)
        {
            rank.sprite = b;
        } else if(score > 5000)
        {
            rank.sprite = c;
        }else
        {
            rank.sprite = f;
        }

    }
}
