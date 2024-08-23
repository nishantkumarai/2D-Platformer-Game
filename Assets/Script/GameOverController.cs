using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] public Button restartButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(SceneRestart);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }


    private static void SceneRestart()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
