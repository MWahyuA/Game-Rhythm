using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManagerPolines: MonoBehaviour
{
    public Image[] healthPoints;

    public int health;
    int maxHealth = 30;
    public static HealthManagerPolines instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
            health = maxHealth;

        HealthBarFiller();
        if(health == 0)
        {
            SceneManager.LoadScene("scorePolines");
        }
    }

    void HealthBarFiller()
    {
        for (int i = 0; i < healthPoints.Length; i++)
        {
            healthPoints[i].enabled = (i < health);
        }
    }

    public void Damage(int damagePoints)
    {
        if (health > 0)
            health -= damagePoints;
    }

}
