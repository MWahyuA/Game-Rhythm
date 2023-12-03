using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerIndo : MonoBehaviour
{
    public static GameManagerIndo instance;
    public int currentScoreIndo;
    public int HighScoreIndo;
    public int badIndo;
    public int poorIndo;
    public int goodIndo;
    public int greatIndo;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerGreatNote = 150;
    public int comboIndo;
    public int HighComboIndo;
    public float akurasiIndo;
    public int healthIndo = 30;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScoreIndo = PlayerPrefs.GetInt("currentScoreIndo", 0);
        HighScoreIndo = PlayerPrefs.GetInt("HighScoreIndo", 0);
        badIndo = PlayerPrefs.GetInt("badIndo", 0);
        poorIndo = PlayerPrefs.GetInt("poorIndo", 0);
        goodIndo = PlayerPrefs.GetInt("goodIndo", 0);
        greatIndo = PlayerPrefs.GetInt("greatIndo", 0);
        comboIndo = PlayerPrefs.GetInt("comboIndo", 0);
        HighComboIndo = PlayerPrefs.GetInt("HighComboIndo", 0);
        akurasiIndo = PlayerPrefs.GetFloat("akurasiIndo", 0);
        healthIndo = PlayerPrefs.GetInt("healthIndo", 0);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("currentScoreIndo", currentScoreIndo);
        PlayerPrefs.SetInt("HighScoreIndo", HighScoreIndo);
        PlayerPrefs.SetInt("badIndo", badIndo);
        PlayerPrefs.SetInt("poorIndo", poorIndo);
        PlayerPrefs.SetInt("goodIndo", goodIndo);
        PlayerPrefs.SetInt("greatIndo", greatIndo);
        PlayerPrefs.SetInt("comboIndo", comboIndo);
        PlayerPrefs.SetInt("HighComboIndo", HighComboIndo);
        PlayerPrefs.SetFloat("akurasiIndo", akurasiIndo);
        PlayerPrefs.SetInt("healthIndo", healthIndo);
    }

    public void NoteHit()
    {
        Debug.Log("Hit On time");
        updateHighComboIndo();
        updateAkurasi();

    }

    public void updateHighScoreIndo()
    {
        if(currentScoreIndo > HighScoreIndo)
        {
            HighScoreIndo = currentScoreIndo;
        }
    }

    public void updateAkurasi()
    {
        float totalNote = badIndo + poorIndo + goodIndo + greatIndo;
        float notePass = totalNote - badIndo;
        akurasiIndo = (notePass / totalNote) * 100f;
    }

    public void updateHighComboIndo()
    {
        if(comboIndo > HighComboIndo)
        {
            HighComboIndo = comboIndo;
        }
    }

    public void NormalHit()
    {
        currentScoreIndo += scorePerNote;
        poorIndo++;
        comboIndo = 0;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScoreIndo += scorePerGoodNote;
        goodIndo++;
        comboIndo++;
        NoteHit();
    }

    public void GreatHit()
    {
        currentScoreIndo += scorePerGreatNote;
        greatIndo++; 
        comboIndo++;
        NoteHit();
    }

    public void NoteMissed()
    {
        badIndo++;
        comboIndo = 0;
        Debug.Log("Missed Note");
        healthIndo--;
        updateAkurasi();
    }

    public void ResetScore()
    {
        currentScoreIndo = 0;
        badIndo = 0;
        poorIndo = 0;
        goodIndo = 0;
        greatIndo = 0;
        comboIndo = 0;
        HighComboIndo = 0;
        akurasiIndo = 0;
        healthIndo = 30;
    }

}
