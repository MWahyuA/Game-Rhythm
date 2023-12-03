using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPolines : MonoBehaviour
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
        GameObject go = GameObject.Find("GameManagerPolines");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManagerPolines gm = go.GetComponent<GameManagerPolines>();

        scoreText.text = gm.currentScorePolines.ToString();
        badText.text = gm.badPolines.ToString();
        poorText.text = gm.poorPolines.ToString();
        goodText.text = gm.goodPolines.ToString();
        greatText.text = gm.greatPolines.ToString();
        combo.text = gm.HighcomboPolines.ToString();
        akurasiText.text = gm.akurasiPolines.ToString()+"%";
        float akurasi = gm.akurasiPolines;
        int score = gm.currentScorePolines;
        int health = gm.healthPolines;

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
            GameManagerPolines.instance.updateHighScorePolines();
            if (!Happy.isPlaying)
            {

                Happy.Play();
            }
        }

        if(score > 5000)
        {
            rank.sprite = splus;
        } else if(score > 4500)
        {
            rank.sprite = s;
        } else if(score > 4000)
        {
            rank.sprite = a;
        }else if(score > 3500)
        {
            rank.sprite = b;
        } else if(score > 3000)
        {
            rank.sprite = c;
        }else
        {
            rank.sprite = f;
        }

    }
}
