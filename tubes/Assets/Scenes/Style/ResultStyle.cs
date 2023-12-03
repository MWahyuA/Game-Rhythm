using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultStyle : MonoBehaviour
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
        GameObject go = GameObject.Find("GameManagerStyle");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManagerStyle gm = go.GetComponent<GameManagerStyle>();

        scoreText.text = gm.currentScoreStyle.ToString();
        badText.text = gm.badStyle.ToString();
        poorText.text = gm.poorStyle.ToString();
        goodText.text = gm.goodStyle.ToString();
        greatText.text = gm.greatStyle.ToString();
        combo.text = gm.HighComboStyle.ToString();
        akurasiText.text = gm.akurasiStyle.ToString()+"%";
        float akurasi = gm.akurasiStyle;
        int score = gm.currentScoreStyle;
        int health = gm.healthStyle;

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
            GameManagerStyle.instance.updateHighScoreStyle();
              if (!Happy.isPlaying)
            {

                Happy.Play();
            }
        }

        if(score > 45000)
        {
            rank.sprite = splus;
        } else if(score > 40000)
        {
            rank.sprite = s;
        } else if(score > 35000)
        {
            rank.sprite = a;
        }else if(score > 30000)
        {
            rank.sprite = b;
        } else if(score > 25000)
        {
            rank.sprite = c;
        }else
        {
            rank.sprite = f;
        }

    }
}
