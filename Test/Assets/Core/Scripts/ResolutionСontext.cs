using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionСontext : MonoBehaviour
{
    public float screenHeightInInchForTab = 8f;
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (CheckIsTablet())
            Screen.orientation = ScreenOrientation.Landscape;
        else
            Screen.orientation = ScreenOrientation.Portrait;
    }

    private bool CheckIsTablet()
    {
        float screenHeightInInch = Screen.height / Screen.dpi;
        if (screenHeightInInch < screenHeightInInchForTab)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
