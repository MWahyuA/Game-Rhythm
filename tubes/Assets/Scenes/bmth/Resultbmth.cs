using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resultbmth : MonoBehaviour
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
        GameObject go = GameObject.Find("GameManagerbmth");

        if (go == null)
        {
            Debug.LogError("Failed find object");
            this.enabled = false;
            return;
        }

        GameManagerbmth gm = go.GetComponent<GameManagerbmth>();

        scoreText.text = gm.currentScorebmth.ToString();
        badText.text = gm.badbmth.ToString();
        poorText.text = gm.poorbmth.ToString();
        goodText.text = gm.goodbmth.ToString();
        greatText.text = gm.greatbmth.ToString();
        combo.text = gm.HighCombobmth.ToString();
        akurasiText.text = gm.akurasibmth.ToString()+"%";
        float akurasi = gm.akurasibmth;
        int score = gm.currentScorebmth;
        int healthbmth = gm.healthbmth;

        if(akurasi < 60 || healthbmth == 0)
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
            GameManagerbmth.instance.updateHighScorebmth();
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
        } else if(score > 25000)
        {
            rank.sprite = a;
        }else if(score > 20000)
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
