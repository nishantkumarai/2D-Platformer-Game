using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button backButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(SceneRestart);
        backButton.onClick.AddListener(LobbyScene);
    }

    private void LobbyScene()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayerDied()
    {
        this.gameObject.SetActive(true); 
    }


    private static void SceneRestart()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
