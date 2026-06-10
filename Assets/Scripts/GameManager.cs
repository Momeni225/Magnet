using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex);
    }
}