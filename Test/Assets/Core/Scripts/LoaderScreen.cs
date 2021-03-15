using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoaderScreen : MonoBehaviour
{
    public Image loadingProgres;
    public float timeToLoad = 3f;

    private Timer _timer;

    public void Start()
    {
        LoadMainScreen();
    }

    public void Update()
    {
        ProgresLoad();
    }

    private void LoadMainScreen()
    {
        _timer = new Timer(timeToLoad);
    }

    private void ProgresLoad()
    {
        _timer.UpdateTimer(Time.deltaTime);
        loadingProgres.fillAmount = _timer.LerpTimeToStop();

        if (_timer.ChekTimer())
            StartMainScreen();
    }

    private void StartMainScreen()
    {
        SceneManager.LoadScene("MainScene");
    }


}
