using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    private void Awake()
    {
        startButton.onClick.AddListener(startClick);
        quitButton.onClick.AddListener(quitClick);
    }
    

    private void quitClick()
    {
       Application.Quit();
    }

    private void startClick()
    {
        SceneManager.LoadScene(1);
    }
}
