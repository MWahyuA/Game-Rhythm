using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerGundul : MonoBehaviour
{
    public static GameManagerGundul instance;
    public int currentScoreGundul;
    public int HighScoreGundul;
    public int badGundul;
    public int poorGundul;
    public int goodGundul;
    public int greatGundul;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerGreatNote = 150;
    public int comboGundul;
    public int HighComboGundul;
    public float akurasiGundul;
    public int healthGundul = 30;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScoreGundul = PlayerPrefs.GetInt("currentScoreGundul", 0);
        HighScoreGundul = PlayerPrefs.GetInt("HighScoreGundul", 0);
        badGundul = PlayerPrefs.GetInt("badGundul", 0);
        poorGundul = PlayerPrefs.GetInt("poorGundul", 0);
        goodGundul = PlayerPrefs.GetInt("goodGundul", 0);
        greatGundul = PlayerPrefs.GetInt("greatGundul", 0);
        comboGundul = PlayerPrefs.GetInt("comboGundul", 0);
        HighComboGundul = PlayerPrefs.GetInt("HighComboGundul", 0);
        akurasiGundul = PlayerPrefs.GetFloat("akurasiGundul", 0);
        healthGundul = PlayerPrefs.GetInt("healthGundul", 0);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("currentScoreGundul", currentScoreGundul);
        PlayerPrefs.SetInt("HighScoreGundul", HighScoreGundul);
        PlayerPrefs.SetInt("badGundul", badGundul);
        PlayerPrefs.SetInt("poorGundul", poorGundul);
        PlayerPrefs.SetInt("goodGundul", goodGundul);
        PlayerPrefs.SetInt("greatGundul", greatGundul);
        PlayerPrefs.SetInt("comboGundul", comboGundul);
        PlayerPrefs.SetInt("HighComboGundul", HighComboGundul);
        PlayerPrefs.SetFloat("akurasiGundul", akurasiGundul);
        PlayerPrefs.SetInt("healthGundul", healthGundul);
    }

    public void NoteHit()
    {
        Debug.Log("Hit On time");
        updateHighComboGundul();
        updateAkurasi();

    }

    public void updateHighScoreGundul()
    {
        if(currentScoreGundul > HighScoreGundul)
        {
            HighScoreGundul = currentScoreGundul;
        }
    }

    public void updateAkurasi()
    {
        float totalNote = badGundul + poorGundul + goodGundul + greatGundul;
        float notePass = totalNote - badGundul;
        akurasiGundul = (notePass / totalNote) * 100f;
    }

    public void updateHighComboGundul()
    {
        if(comboGundul > HighComboGundul)
        {
            HighComboGundul = comboGundul;
        }
    }

    public void NormalHit()
    {
        currentScoreGundul += scorePerNote;
        poorGundul++;
        comboGundul = 0;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScoreGundul += scorePerGoodNote;
        goodGundul++;
        comboGundul++;
        NoteHit();
    }

    public void GreatHit()
    {
        currentScoreGundul += scorePerGreatNote;
        greatGundul++; 
        comboGundul++;
        NoteHit();
    }

    public void NoteMissed()
    {
        badGundul++;
        comboGundul = 0;
        Debug.Log("Missed Note");
        healthGundul--;
        updateAkurasi();
    }

    public void ResetScore()
    {
        currentScoreGundul = 0;
        badGundul = 0;
        poorGundul = 0;
        goodGundul = 0;
        greatGundul = 0;
        comboGundul = 0;
        HighComboGundul = 0;
        akurasiGundul = 0;
        healthGundul = 30;
    }

}
