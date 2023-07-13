using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public static int starsis = 3;

    public Image[] stars; // Массив компонентов 
    public Sprite fullStar; 
    public Sprite emptyStar; 

    private void Awake()
    {
        starsis = 3; 
    }

    
    void Update()
    {
        foreach (Image image in stars)
        {
            image.sprite = emptyStar; // Установка спрайта emptyStar для всех компонентов Image звезд.
        }

        for (int i = 0; i < starsis; i++)
        {
            stars[i].sprite = fullStar; // Установка спрайта fullStar для соответствующих компонентов Image звезд.
        }
    }
}
