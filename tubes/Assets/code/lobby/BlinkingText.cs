using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    private Text textComponent;
    private Color originalColor;
    public Color changeColor;
    public AudioSource bgm1;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<Text>();
        originalColor = textComponent.color;

        StartCoroutine(BlinkText());
    }

    // Update is called once per frame
    void Update()
    {
        if (!bgm1.isPlaying)
        {
            bgm1.Play();
        }
    }
    IEnumerator BlinkText()
    {
        while (true)
        {
            textComponent.color = originalColor;
            yield return new WaitForSeconds(0.5f);
            textComponent.color = changeColor;
            yield return new WaitForSeconds(0.5f);
        }
    }

}
