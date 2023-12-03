using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSeven : MonoBehaviour
{
    public static GameManagerSeven instance;
    public int currentScoreSeven;
    public int HighScoreSeven;
    public int badSeven;
    public int poorSeven;
    public int goodSeven;
    public int greatSeven;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerGreatNote = 150;
    public int comboSeven;
    public int HighComboSeven;
    public float akurasiSeven;
    public int healthSeven = 30;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScoreSeven = PlayerPrefs.GetInt("currentScoreSeven", 0);
        HighScoreSeven = PlayerPrefs.GetInt("HighScoreSeven", 0);
        badSeven = PlayerPrefs.GetInt("badSeven", 0);
        poorSeven = PlayerPrefs.GetInt("poorSeven", 0);
        goodSeven = PlayerPrefs.GetInt("goodSeven", 0);
        greatSeven = PlayerPrefs.GetInt("greatSeven", 0);
        comboSeven = PlayerPrefs.GetInt("comboSeven", 0);
        HighComboSeven = PlayerPrefs.GetInt("HighComboSeven", 0);
        akurasiSeven = PlayerPrefs.GetFloat("akurasiSeven", 0);
        healthSeven = PlayerPrefs.GetInt("healthSeven", 0);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("currentScoreSeven", currentScoreSeven);
        PlayerPrefs.SetInt("HighScoreSeven", HighScoreSeven);
        PlayerPrefs.SetInt("badSeven", badSeven);
        PlayerPrefs.SetInt("poorSeven", poorSeven);
        PlayerPrefs.SetInt("goodSeven", goodSeven);
        PlayerPrefs.SetInt("greatSeven", greatSeven);
        PlayerPrefs.SetInt("comboSeven", comboSeven);
        PlayerPrefs.SetInt("HighComboSeven", HighComboSeven);
        PlayerPrefs.SetFloat("akurasiSeven", akurasiSeven);
        PlayerPrefs.SetInt("healthSeven", healthSeven);
    }

    public void NoteHit()
    {
        Debug.Log("Hit On time");
        updateHighComboSeven();
        updateAkurasi();

    }

    public void updateHighScoreSeven()
    {
        if(currentScoreSeven > HighScoreSeven)
        {
            HighScoreSeven = currentScoreSeven;
        }
    }

    public void updateAkurasi()
    {
        float totalNote = badSeven + poorSeven + goodSeven + greatSeven;
        float notePass = totalNote - badSeven;
        akurasiSeven = (notePass / totalNote) * 100f;
    }

    public void updateHighComboSeven()
    {
        if(comboSeven > HighComboSeven)
        {
            HighComboSeven = comboSeven;
        }
    }

    public void NormalHit()
    {
        currentScoreSeven += scorePerNote;
        poorSeven++;
        comboSeven = 0;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScoreSeven += scorePerGoodNote;
        goodSeven++;
        comboSeven++;
        NoteHit();
    }

    public void GreatHit()
    {
        currentScoreSeven += scorePerGreatNote;
        greatSeven++; 
        comboSeven++;
        NoteHit();
    }

    public void NoteMissed()
    {
        badSeven++;
        comboSeven = 0;
        Debug.Log("Missed Note");
        healthSeven--;
        updateAkurasi();
    }

    public void ResetScore()
    {
        currentScoreSeven = 0;
        badSeven = 0;
        poorSeven = 0;
        goodSeven = 0;
        greatSeven = 0;
        comboSeven = 0;
        HighComboSeven = 0;
        akurasiSeven = 0;
        healthSeven = 30;
    }

}
