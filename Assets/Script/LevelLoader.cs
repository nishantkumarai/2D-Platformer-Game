using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    public Button levelButton;
    public string levelName;

    private void Awake()
    {
        levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(playLevel);
    }

    private void playLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
