using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public static int starsis = 3;

    public Image[] stars; // ������ ����������� 
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
            image.sprite = emptyStar; // ��������� ������� emptyStar ��� ���� ����������� Image �����.
        }

        for (int i = 0; i < starsis; i++)
        {
            stars[i].sprite = fullStar; // ��������� ������� fullStar ��� ��������������� ����������� Image �����.
        }
    }
}
