using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObjectbmth : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public AudioSource Miss;
    public bool scale;
    public float scaleTempo = 0.35f;

    public Vector3 maxScale = new Vector3(1f, 1f, 1f);

    public bool button1;
    public bool button2;
    public bool button3;
    public bool button4;

    public GameObject poorEffect, goodEffect, badEffect, greatEffect;
    public GameObject character;
    public Animator animator;

    private bool isStart;
    private bool isHappy;
    private bool isMiss;
    private bool isPoor;
    private bool cekMiss;

    private void Start()
    {
        isStart = true;
        isMiss = false;
        isPoor = false;
        isHappy = false;
        cekMiss = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            cekMiss = false;
            if (canBePressed)
            {
                gameObject.SetActive(false);
                float notePosition = transform.position.y;
                if (Mathf.Abs(notePosition) > 0.25f)
                {
                    Debug.Log("Hit");
                    GameManagerbmth.instance.NormalHit();
                    Instantiate(poorEffect, transform.position, poorEffect.transform.rotation);
                    isPoor = true;
                    isHappy = false;
                    isStart = false;
                    isMiss = false;
                    animator.SetBool("isHappy", isHappy);
                    animator.SetBool("isPoor", isPoor);
                    animator.SetBool("isStart", isStart);
                    animator.SetBool("isMiss", isMiss);

                }
                else if (Mathf.Abs(notePosition) > 0.05f && Mathf.Abs(notePosition) <= 0.25f)
                {
                    Debug.Log("Good");
                    GameManagerbmth.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    isHappy = true;
                    isPoor = false;
                    isStart = false;
                    isMiss = false;
                    animator.SetBool("isHappy", isHappy);
                    animator.SetBool("isPoor", isPoor);
                    animator.SetBool("isStart", isStart);
                    animator.SetBool("isMiss", isMiss);
                }
                else
                {
                    Debug.Log("Great");
                    GameManagerbmth.instance.GreatHit();
                    Instantiate(greatEffect, transform.position, greatEffect.transform.rotation);
                    isHappy = true;
                    isPoor = false;
                    isStart = false;
                    isMiss = false;
                    animator.SetBool("isHappy", isHappy);
                    animator.SetBool("isPoor", isPoor);
                    animator.SetBool("isStart", isStart);
                    animator.SetBool("isMiss", isMiss);
                }
            }
        } else
        {
            if (cekMiss)
            {
                isHappy = false;
                isPoor = false;
                isStart = false;
                isMiss = true;
                animator.SetBool("isHappy", isHappy);
                animator.SetBool("isPoor", isPoor);
                animator.SetBool("isStart", isStart);
                animator.SetBool("isMiss", isMiss);
            }
            else
            {

            }
        }

          if(scale)
            {
            transform.localScale += new Vector3(scaleTempo * Time.deltaTime, scaleTempo * Time.deltaTime, 0f);

            transform.localScale = Vector3.Min(transform.localScale, maxScale);

            if (button4)
            {
                transform.position -= new Vector3(0.57f * Time.deltaTime, 0f, 0f);
            }

            if (button3)
            {
                transform.position -= new Vector3(0.18f * Time.deltaTime, 0f, 0f);
            }

            if (button2)
            {
                transform.position += new Vector3(0.24f * Time.deltaTime, 0f, 0f);
            }

            if (button1)
            {
                transform.position += new Vector3(0.52f * Time.deltaTime, 0f, 0f);
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
            cekMiss = false;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;
            GameManagerbmth.instance.NoteMissed();
            Instantiate(badEffect, transform.position, badEffect.transform.rotation);
            Miss.Play();
            HealthManagerbmth.instance.Damage(1);
            cekMiss = true;
        }

           if (other.tag == "Scale")
        {
            scale = true;
        }
    }


}
