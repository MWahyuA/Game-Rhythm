using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerStyle : MonoBehaviour
{
    public static GameManagerStyle instance;
    public int currentScoreStyle;
    public int HighScoreStyle;
    public int badStyle;
    public int poorStyle;
    public int goodStyle;
    public int greatStyle;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerGreatNote = 150;
    public int comboStyle;
    public int HighComboStyle;
    public float akurasiStyle;
    public int healthStyle = 30;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScoreStyle = PlayerPrefs.GetInt("currentScoreStyle", 0);
        HighScoreStyle = PlayerPrefs.GetInt("HighScoreStyle", 0);
        badStyle = PlayerPrefs.GetInt("badStyle", 0);
        poorStyle = PlayerPrefs.GetInt("poorStyle", 0);
        goodStyle = PlayerPrefs.GetInt("goodStyle", 0);
        greatStyle = PlayerPrefs.GetInt("greatStyle", 0);
        comboStyle = PlayerPrefs.GetInt("comboStyle", 0);
        HighComboStyle = PlayerPrefs.GetInt("HighComboStyle", 0);
        akurasiStyle = PlayerPrefs.GetFloat("akurasiStyle", 0);
        healthStyle = PlayerPrefs.GetInt("healthStyle", 0);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("currentScoreStyle", currentScoreStyle);
        PlayerPrefs.SetInt("HighScoreStyle", HighScoreStyle);
        PlayerPrefs.SetInt("badStyle", badStyle);
        PlayerPrefs.SetInt("poorStyle", poorStyle);
        PlayerPrefs.SetInt("goodStyle", goodStyle);
        PlayerPrefs.SetInt("greatStyle", greatStyle);
        PlayerPrefs.SetInt("comboStyle", comboStyle);
        PlayerPrefs.SetInt("HighComboStyle", HighComboStyle);
        PlayerPrefs.SetFloat("akurasiStyle", akurasiStyle);
        PlayerPrefs.SetInt("healthStyle", healthStyle);
    }

    public void NoteHit()
    {
        Debug.Log("Hit On time");
        updateHighComboStyle();
        updateAkurasi();

    }

    public void updateHighScoreStyle()
    {
        if(currentScoreStyle > HighScoreStyle)
        {
            HighScoreStyle = currentScoreStyle;
        }
    }

    public void updateAkurasi()
    {
        float totalNote = badStyle + poorStyle + goodStyle + greatStyle;
        float notePass = totalNote - badStyle;
        akurasiStyle = (notePass / totalNote) * 100f;
    }

    public void updateHighComboStyle()
    {
        if(comboStyle > HighComboStyle)
        {
            HighComboStyle = comboStyle;
        }
    }

    public void NormalHit()
    {
        currentScoreStyle += scorePerNote;
        poorStyle++;
        comboStyle = 0;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScoreStyle += scorePerGoodNote;
        goodStyle++;
        comboStyle++;
        NoteHit();
    }

    public void GreatHit()
    {
        currentScoreStyle += scorePerGreatNote;
        greatStyle++; 
        comboStyle++;
        NoteHit();
    }

    public void NoteMissed()
    {
        badStyle++;
        comboStyle = 0;
        Debug.Log("Missed Note");
        healthStyle--;
        updateAkurasi();
    }

    public void ResetScore()
    {
        currentScoreStyle = 0;
        badStyle = 0;
        poorStyle = 0;
        goodStyle = 0;
        greatStyle = 0;
        comboStyle = 0;
        HighComboStyle = 0;
        akurasiStyle = 0;
        healthStyle = 30;
    }

}
