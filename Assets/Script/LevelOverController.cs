using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    //[SerializeField]
    //private string level;
    public GameObject levelUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level finish by player");
            LevelManager.Instance.MarkCurrentLevelComplete();
            //SceneManager.LoadScene(level);
            levelUI.SetActive(true);
        }
    }
}
