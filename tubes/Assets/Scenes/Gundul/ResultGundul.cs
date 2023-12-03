using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultGundul : MonoBehaviour
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
        GameObject go = GameObject.Find("GameManagerGundul");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManagerGundul gm = go.GetComponent<GameManagerGundul>();

        scoreText.text = gm.currentScoreGundul.ToString();
        badText.text = gm.badGundul.ToString();
        poorText.text = gm.poorGundul.ToString();
        goodText.text = gm.goodGundul.ToString();
        greatText.text = gm.greatGundul.ToString();
        combo.text = gm.HighComboGundul.ToString();
        akurasiText.text = gm.akurasiGundul.ToString()+"%";
        float akurasi = gm.akurasiGundul;
        int score = gm.currentScoreGundul;
        int healthGundul = gm.healthGundul;

        if(akurasi < 60 || healthGundul == 0)
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
            GameManagerGundul.instance.updateHighScoreGundul();
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
