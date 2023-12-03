using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerFancy : MonoBehaviour
{
    public static GameManagerFancy instance;
    public int currentScoreFancy;
    public int HighScoreFancy;
    public int badFancy;
    public int poorFancy;
    public int goodFancy;
    public int greatFancy;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerGreatNote = 150;
    public int comboFancy;
    public int HighComboFancy;
    public float akurasiFancy;
    public int healthFancy = 30;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScoreFancy = PlayerPrefs.GetInt("currentScoreFancy", 0);
        HighScoreFancy = PlayerPrefs.GetInt("HighScoreFancy", 0);
        badFancy = PlayerPrefs.GetInt("badFancy", 0);
        poorFancy = PlayerPrefs.GetInt("poorFancy", 0);
        goodFancy = PlayerPrefs.GetInt("goodFancy", 0);
        greatFancy = PlayerPrefs.GetInt("greatFancy", 0);
        comboFancy = PlayerPrefs.GetInt("comboFancy", 0);
        HighComboFancy = PlayerPrefs.GetInt("HighComboFancy", 0);
        akurasiFancy = PlayerPrefs.GetFloat("akurasiFancy", 0);
        healthFancy = PlayerPrefs.GetInt("healthFancy", 0);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("currentScoreFancy", currentScoreFancy);
        PlayerPrefs.SetInt("HighScoreFancy", HighScoreFancy);
        PlayerPrefs.SetInt("badFancy", badFancy);
        PlayerPrefs.SetInt("poorFancy", poorFancy);
        PlayerPrefs.SetInt("goodFancy", goodFancy);
        PlayerPrefs.SetInt("greatFancy", greatFancy);
        PlayerPrefs.SetInt("comboFancy", comboFancy);
        PlayerPrefs.SetInt("HighComboFancy", HighComboFancy);
        PlayerPrefs.SetFloat("akurasiFancy", akurasiFancy);
        PlayerPrefs.SetInt("healthFancy", healthFancy);
    }

    public void NoteHit()
    {
        Debug.Log("Hit On time");
        updateHighComboFancy();
        updateAkurasi();

    }

    public void updateHighScoreFancy()
    {
        if(currentScoreFancy > HighScoreFancy)
        {
            HighScoreFancy = currentScoreFancy;
        }
    }

    public void updateAkurasi()
    {
        float totalNote = badFancy + poorFancy + goodFancy + greatFancy;
        float notePass = totalNote - badFancy;
        akurasiFancy = (notePass / totalNote) * 100f;
    }

    public void updateHighComboFancy()
    {
        if(comboFancy > HighComboFancy)
        {
            HighComboFancy = comboFancy;
        }
    }

    public void NormalHit()
    {
        currentScoreFancy += scorePerNote;
        poorFancy++;
        comboFancy = 0;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScoreFancy += scorePerGoodNote;
        goodFancy++;
        comboFancy++;
        NoteHit();
    }

    public void GreatHit()
    {
        currentScoreFancy += scorePerGreatNote;
        greatFancy++; 
        comboFancy++;
        NoteHit();
    }

    public void NoteMissed()
    {
        badFancy++;
        comboFancy = 0;
        Debug.Log("Missed Note");
        healthFancy--;
        updateAkurasi();
    }

    public void ResetScore()
    {
        currentScoreFancy = 0;
        badFancy = 0;
        poorFancy = 0;
        goodFancy = 0;
        greatFancy = 0;
        comboFancy = 0;
        HighComboFancy = 0;
        akurasiFancy = 0;
        healthFancy = 30;
    }

}
