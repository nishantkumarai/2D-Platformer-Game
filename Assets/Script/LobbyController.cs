using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public GameObject levelUI;

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
        SoundManager.Instance.Play(Sounds.ButtonClick);
        levelUI.SetActive(true);
    }
}
