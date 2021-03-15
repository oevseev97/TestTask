using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ThemeTable : MonoBehaviour
{
    public Image TableImg;

    [HideInInspector]
    public int IndexCurentTheme = 0;

    private RectTransform _rect;

    private Vector2 _defaultPosition;

    public void Awake()
    {
        _defaultPosition = transform.position;
        _rect = GetComponent<RectTransform>();
        IndexCurentTheme = PlayerPrefs.GetInt("IndexCurentTheme", 0);
        ApplyingTheme();
    }

    public void ShowThemeScreen()
    {
        _rect.DOAnchorPos(Vector2.zero, 0.5f);
    }

    public void SetTheme(int index)
    {
        IndexCurentTheme = index;
        PlayerPrefs.SetInt("IndexCurentTheme", IndexCurentTheme);
        ApplyingTheme();
    }

    public void CloseThemeScreen()
    {
        transform.DOMove(_defaultPosition, 0.5f);
    }

    private void ApplyingTheme()
    {
        switch(IndexCurentTheme)
        {
            case 0: 
                {
                    TableImg.color = Color.white;
                    break;
                }

            case 1:
                {
                    TableImg.color = Color.red;
                    break;
                }

            case 2:
                {
                    TableImg.color = Color.blue;
                    break;
                }

        }
    }
}
