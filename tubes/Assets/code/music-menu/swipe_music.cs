using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipe_music : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_poss = 0;
    float[] pos;

    void Update()
    {
    pos = new float[transform.childCount];
    float distance = 1f / (pos.Length - 1f);

    for (int i = 0; i < pos.Length; i++)
    {
        pos[i] = distance * i;
    }

    scroll_poss = 1 - scrollbar.GetComponent<Scrollbar>().value;

    int currentIndex = -1;
    float minDistance = float.MaxValue;

    for (int i = 0; i < pos.Length; i++)
    {
        float centerPos = Mathf.Abs(pos[i] - scroll_poss);

        if (centerPos < minDistance)
        {
            minDistance = centerPos;
            currentIndex = i;
        }
    }

    for (int i = 0; i < pos.Length; i++)
    {
        float targetScale = (i == currentIndex) ? 1f : 0.7f;
        transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(targetScale, targetScale), 0.1f);
    }   
    }   
}
