using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerKurenai : MonoBehaviour
{
    public static GameManagerKurenai instance;
    public int currentScoreKurenai;
    public int HighScoreKurenai;
    public int badKurenai;
    public int poorKurenai;
    public int goodKurenai;
    public int greatKurenai;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerGreatNote = 150;
    public int comboKurenai;
    public int HighComboKurenai;
    public float akurasiKurenai;
    public int healthKurenai = 30;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScoreKurenai = PlayerPrefs.GetInt("currentScoreKurenai", 0);
        HighScoreKurenai = PlayerPrefs.GetInt("HighScoreKurenai", 0);
        badKurenai = PlayerPrefs.GetInt("badKurenai", 0);
        poorKurenai = PlayerPrefs.GetInt("poorKurenai", 0);
        goodKurenai = PlayerPrefs.GetInt("goodKurenai", 0);
        greatKurenai = PlayerPrefs.GetInt("greatKurenai", 0);
        comboKurenai = PlayerPrefs.GetInt("comboKurenai", 0);
        HighComboKurenai = PlayerPrefs.GetInt("HighComboKurenai", 0);
        akurasiKurenai = PlayerPrefs.GetFloat("akurasiKurenai", 0);
        healthKurenai = PlayerPrefs.GetInt("healthKurenai", 0);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("currentScoreKurenai", currentScoreKurenai);
        PlayerPrefs.SetInt("HighScoreKurenai", HighScoreKurenai);
        PlayerPrefs.SetInt("badKurenai", badKurenai);
        PlayerPrefs.SetInt("poorKurenai", poorKurenai);
        PlayerPrefs.SetInt("goodKurenai", goodKurenai);
        PlayerPrefs.SetInt("greatKurenai", greatKurenai);
        PlayerPrefs.SetInt("comboKurenai", comboKurenai);
        PlayerPrefs.SetInt("HighComboKurenai", HighComboKurenai);
        PlayerPrefs.SetFloat("akurasiKurenai", akurasiKurenai);
        PlayerPrefs.SetInt("healthKurenai", healthKurenai);
    }

    public void NoteHit()
    {
        Debug.Log("Hit On time");
        updateHighComboKurenai();
        updateAkurasi();

    }

    public void updateHighScoreKurenai()
    {
        if(currentScoreKurenai > HighScoreKurenai)
        {
            HighScoreKurenai = currentScoreKurenai;
        }
    }

    public void updateAkurasi()
    {
        float totalNote = badKurenai + poorKurenai + goodKurenai + greatKurenai;
        float notePass = totalNote - badKurenai;
        akurasiKurenai = (notePass / totalNote) * 100f;
    }

    public void updateHighComboKurenai()
    {
        if(comboKurenai > HighComboKurenai)
        {
            HighComboKurenai = comboKurenai;
        }
    }

    public void NormalHit()
    {
        currentScoreKurenai += scorePerNote;
        poorKurenai++;
        comboKurenai = 0;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScoreKurenai += scorePerGoodNote;
        goodKurenai++;
        comboKurenai++;
        NoteHit();
    }

    public void GreatHit()
    {
        currentScoreKurenai += scorePerGreatNote;
        greatKurenai++; 
        comboKurenai++;
        NoteHit();
    }

    public void NoteMissed()
    {
        badKurenai++;
        comboKurenai = 0;
        Debug.Log("Missed Note");
        healthKurenai--;
        updateAkurasi();
    }

    public void ResetScore()
    {
        currentScoreKurenai = 0;
        badKurenai = 0;
        poorKurenai = 0;
        goodKurenai = 0;
        greatKurenai = 0;
        comboKurenai = 0;
        HighComboKurenai = 0;
        akurasiKurenai = 0;
        healthKurenai = 30;
    }

}
