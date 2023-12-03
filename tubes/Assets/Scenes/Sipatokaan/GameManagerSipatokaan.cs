using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSipatokaan : MonoBehaviour
{
    public static GameManagerSipatokaan instance;
    public int currentScoreSipatokaan;
    public int HighScoreSipatokaan;
    public int badSipatokaan;
    public int poorSipatokaan;
    public int goodSipatokaan;
    public int greatSipatokaan;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerGreatNote = 150;
    public int comboSipatokaan;
    public int HighcomboSipatokaan;
    public float akurasiSipatokaan;
    public int healthSipatokaan = 30;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScoreSipatokaan = PlayerPrefs.GetInt("currentScoreSipatokaan", 0);
        HighScoreSipatokaan = PlayerPrefs.GetInt("HighScoreSipatokaan", 0);
        badSipatokaan = PlayerPrefs.GetInt("badSipatokaan", 0);
        poorSipatokaan = PlayerPrefs.GetInt("poorSipatokaan", 0);
        goodSipatokaan = PlayerPrefs.GetInt("goodSipatokaan", 0);
        greatSipatokaan = PlayerPrefs.GetInt("greatSipatokaan", 0);
        comboSipatokaan = PlayerPrefs.GetInt("comboSipatokaan", 0);
        HighcomboSipatokaan = PlayerPrefs.GetInt("HighcomboSipatokaan", 0);
        akurasiSipatokaan = PlayerPrefs.GetFloat("akurasiSipatokaan", 0);
        healthSipatokaan = PlayerPrefs.GetInt("healthSipatokaan", 0);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("currentScoreSipatokaan", currentScoreSipatokaan);
        PlayerPrefs.SetInt("HighScoreSipatokaan", HighScoreSipatokaan);
        PlayerPrefs.SetInt("badSipatokaan", badSipatokaan);
        PlayerPrefs.SetInt("poorSipatokaan", poorSipatokaan);
        PlayerPrefs.SetInt("goodSipatokaan", goodSipatokaan);
        PlayerPrefs.SetInt("greatSipatokaan", greatSipatokaan);
        PlayerPrefs.SetInt("comboSipatokaan", comboSipatokaan);
        PlayerPrefs.SetInt("HighcomboSipatokaan", HighcomboSipatokaan);
        PlayerPrefs.SetFloat("akurasiSipatokaan", akurasiSipatokaan);
        PlayerPrefs.SetInt("healthSipatokaan", healthSipatokaan);
    }

    public void NoteHit()
    {
        Debug.Log("Hit On time");
        updateHighcomboSipatokaan();
        updateAkurasi();

    }

    public void updateHighScoreSipatokaan()
    {
        if(currentScoreSipatokaan > HighScoreSipatokaan)
        {
            HighScoreSipatokaan = currentScoreSipatokaan;
        }
    }

    public void updateAkurasi()
    {
        float totalNote = badSipatokaan + poorSipatokaan + goodSipatokaan + greatSipatokaan;
        float notePass = totalNote - badSipatokaan;
        akurasiSipatokaan = (notePass / totalNote) * 100f;
    }

    public void updateHighcomboSipatokaan()
    {
        if(comboSipatokaan > HighcomboSipatokaan)
        {
            HighcomboSipatokaan = comboSipatokaan;
        }
    }

    public void NormalHit()
    {
        currentScoreSipatokaan += scorePerNote;
        poorSipatokaan++;
        comboSipatokaan = 0;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScoreSipatokaan += scorePerGoodNote;
        goodSipatokaan++;
        comboSipatokaan++;
        NoteHit();
    }

    public void GreatHit()
    {
        currentScoreSipatokaan += scorePerGreatNote;
        greatSipatokaan++; 
        comboSipatokaan++;
        NoteHit();
    }

    public void NoteMissed()
    {
        badSipatokaan++;
        comboSipatokaan = 0;
        Debug.Log("Missed Note");
        healthSipatokaan--;
        updateAkurasi();
    }

    public void ResetScore()
    {
        currentScoreSipatokaan = 0;
        badSipatokaan = 0;
        poorSipatokaan = 0;
        goodSipatokaan = 0;
        greatSipatokaan = 0;
        comboSipatokaan = 0;
        HighcomboSipatokaan = 0;
        akurasiSipatokaan = 0;
        healthSipatokaan = 30;
    }

}
