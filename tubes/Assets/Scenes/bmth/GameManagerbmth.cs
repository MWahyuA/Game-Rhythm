using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerbmth : MonoBehaviour
{
    public static GameManagerbmth instance;
    public int currentScorebmth;
    public int HighScorebmth;
    public int badbmth;
    public int poorbmth;
    public int goodbmth;
    public int greatbmth;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerGreatNote = 150;
    public int combobmth;
    public int HighCombobmth;
    public float akurasibmth;
    public int healthbmth = 30;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScorebmth = PlayerPrefs.GetInt("currentScorebmth", 0);
        HighScorebmth = PlayerPrefs.GetInt("HighScorebmth", 0);
        badbmth = PlayerPrefs.GetInt("badbmth", 0);
        poorbmth = PlayerPrefs.GetInt("poorbmth", 0);
        goodbmth = PlayerPrefs.GetInt("goodbmth", 0);
        greatbmth = PlayerPrefs.GetInt("greatbmth", 0);
        combobmth = PlayerPrefs.GetInt("combobmth", 0);
        HighCombobmth = PlayerPrefs.GetInt("HighCombobmth", 0);
        akurasibmth = PlayerPrefs.GetFloat("akurasibmth", 0);
        healthbmth = PlayerPrefs.GetInt("healthbmth", 0);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("currentScorebmth", currentScorebmth);
        PlayerPrefs.SetInt("HighScorebmth", HighScorebmth);
        PlayerPrefs.SetInt("badbmth", badbmth);
        PlayerPrefs.SetInt("poorbmth", poorbmth);
        PlayerPrefs.SetInt("goodbmth", goodbmth);
        PlayerPrefs.SetInt("greatbmth", greatbmth);
        PlayerPrefs.SetInt("combobmth", combobmth);
        PlayerPrefs.SetInt("HighCombobmth", HighCombobmth);
        PlayerPrefs.SetFloat("akurasibmth", akurasibmth);
        PlayerPrefs.SetInt("healthbmth", healthbmth);
    }

    public void NoteHit()
    {
        Debug.Log("Hit On time");
        updateHighCombobmth();
        updateAkurasi();

    }

    public void updateHighScorebmth()
    {
        if(currentScorebmth > HighScorebmth)
        {
            HighScorebmth = currentScorebmth;
        }
    }

    public void updateAkurasi()
    {
        float totalNote = badbmth + poorbmth + goodbmth + greatbmth;
        float notePass = totalNote - badbmth;
        akurasibmth = (notePass / totalNote) * 100f;
    }

    public void updateHighCombobmth()
    {
        if(combobmth > HighCombobmth)
        {
            HighCombobmth = combobmth;
        }
    }

    public void NormalHit()
    {
        currentScorebmth += scorePerNote;
        poorbmth++;
        combobmth = 0;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScorebmth += scorePerGoodNote;
        goodbmth++;
        combobmth++;
        NoteHit();
    }

    public void GreatHit()
    {
        currentScorebmth += scorePerGreatNote;
        greatbmth++; 
        combobmth++;
        NoteHit();
    }

    public void NoteMissed()
    {
        badbmth++;
        combobmth = 0;
        Debug.Log("Missed Note");
        healthbmth--;
        updateAkurasi();
    }

    public void ResetScore()
    {
        currentScorebmth = 0;
        badbmth = 0;
        poorbmth = 0;
        goodbmth = 0;
        greatbmth = 0;
        combobmth = 0;
        HighCombobmth = 0;
        akurasibmth = 0;
        healthbmth = 30;
    }

}
