using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerPolines : MonoBehaviour
{
    public static GameManagerPolines instance;
    public int currentScorePolines;
    public int HighScorePolines;
    public int badPolines;
    public int poorPolines;
    public int goodPolines;
    public int greatPolines;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerGreatNote = 150;
    public int comboPolines;
    public int HighcomboPolines;
    public float akurasiPolines;
    public int healthPolines = 30;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScorePolines = PlayerPrefs.GetInt("currentScorePolines", 0);
        HighScorePolines = PlayerPrefs.GetInt("HighScorePolines", 0);
        badPolines = PlayerPrefs.GetInt("badPolines", 0);
        poorPolines = PlayerPrefs.GetInt("poorPolines", 0);
        goodPolines = PlayerPrefs.GetInt("goodPolines", 0);
        greatPolines = PlayerPrefs.GetInt("greatPolines", 0);
        comboPolines = PlayerPrefs.GetInt("comboPolines", 0);
        HighcomboPolines = PlayerPrefs.GetInt("HighcomboPolines", 0);
        akurasiPolines = PlayerPrefs.GetFloat("akurasiPolines", 0);
        healthPolines = PlayerPrefs.GetInt("healthPolinesPolines", 0);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("currentScorePolines", currentScorePolines);
        PlayerPrefs.SetInt("HighScorePolines", HighScorePolines);
        PlayerPrefs.SetInt("badPolines", badPolines);
        PlayerPrefs.SetInt("poorPolines", poorPolines);
        PlayerPrefs.SetInt("goodPolines", goodPolines);
        PlayerPrefs.SetInt("greatPolines", greatPolines);
        PlayerPrefs.SetInt("comboPolines", comboPolines);
        PlayerPrefs.SetInt("HighcomboPolines", HighcomboPolines);
        PlayerPrefs.SetFloat("akurasiPolines", akurasiPolines);
        PlayerPrefs.SetInt("healthPolinesPolines", healthPolines);
    }

    public void NoteHit()
    {
        Debug.Log("Hit On time");
        updateHighcomboPolines();
        updateAkurasi();

    }

    public void updateHighScorePolines()
    {
        if(currentScorePolines > HighScorePolines)
        {
            HighScorePolines = currentScorePolines;
        }
    }

    public void updateAkurasi()
    {
        float totalNote = badPolines + poorPolines + goodPolines + greatPolines;
        float notePass = totalNote - badPolines;
        akurasiPolines = (notePass / totalNote) * 100f;
    }

    public void updateHighcomboPolines()
    {
        if(comboPolines > HighcomboPolines)
        {
            HighcomboPolines = comboPolines;
        }
    }

    public void NormalHit()
    {
        currentScorePolines += scorePerNote;
        poorPolines++;
        comboPolines = 0;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScorePolines += scorePerGoodNote;
        goodPolines++;
        comboPolines++;
        NoteHit();
    }

    public void GreatHit()
    {
        currentScorePolines += scorePerGreatNote;
        greatPolines++; 
        comboPolines++;
        NoteHit();
    }

    public void NoteMissed()
    {
        badPolines++;
        comboPolines = 0;
        Debug.Log("Missed Note");
        healthPolines--;
        updateAkurasi();
    }

    public void ResetScore()
    {
        currentScorePolines = 0;
        badPolines = 0;
        poorPolines = 0;
        goodPolines = 0;
        greatPolines = 0;
        comboPolines = 0;
        HighcomboPolines = 0;
        akurasiPolines = 0;
        healthPolines = 30;
    }

}
