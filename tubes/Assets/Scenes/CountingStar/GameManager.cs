using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentScore;
    public int HighScore;
    public int bad;
    public int poor;
    public int good;
    public int great;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerGreatNote = 150;
    public int combo;
    public int HighCombo;
    public float akurasi;
    public int health = 30;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScore = PlayerPrefs.GetInt("currentScore", 0);
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        bad = PlayerPrefs.GetInt("bad", 0);
        poor = PlayerPrefs.GetInt("poor", 0);
        good = PlayerPrefs.GetInt("good", 0);
        great = PlayerPrefs.GetInt("great", 0);
        combo = PlayerPrefs.GetInt("combo", 0);
        HighCombo = PlayerPrefs.GetInt("HighCombo", 0);
        akurasi = PlayerPrefs.GetFloat("akurasi", 0);
        health = PlayerPrefs.GetInt("health", 0);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("currentScore", currentScore);
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.SetInt("bad", bad);
        PlayerPrefs.SetInt("poor", poor);
        PlayerPrefs.SetInt("good", good);
        PlayerPrefs.SetInt("great", great);
        PlayerPrefs.SetInt("combo", combo);
        PlayerPrefs.SetInt("HighCombo", HighCombo);
        PlayerPrefs.SetFloat("akurasi", akurasi);
        PlayerPrefs.SetInt("health", health);
    }

    public void NoteHit()
    {
        Debug.Log("Hit On time");
        updateHighCombo();
        updateAkurasi();

    }

    public void updateHighScore()
    {
        if(currentScore > HighScore)
        {
            HighScore = currentScore;
        }
    }

    public void updateAkurasi()
    {
        float totalNote = bad + poor + good + great;
        float notePass = totalNote - bad;
        akurasi = (notePass / totalNote) * 100f;
    }

    public void updateHighCombo()
    {
        if(combo > HighCombo)
        {
            HighCombo = combo;
        }
    }

    public void NormalHit()
    {
        currentScore += scorePerNote;
        poor++;
        combo = 0;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote;
        good++;
        combo++;
        NoteHit();
    }

    public void GreatHit()
    {
        currentScore += scorePerGreatNote;
        great++; 
        combo++;
        NoteHit();
    }

    public void NoteMissed()
    {
        bad++;
        combo = 0;
        Debug.Log("Missed Note");
        health--;
        updateAkurasi();
    }

    public void ResetScore()
    {
        currentScore = 0;
        bad = 0;
        poor = 0;
        good = 0;
        great = 0;
        combo = 0;
        HighCombo = 0;
        akurasi = 0;
        health = 30;
    }

}
