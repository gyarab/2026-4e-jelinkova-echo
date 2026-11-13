using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; //panel escape systemu

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false); //skryje se panel escape systemu
        Time.timeScale = 1f; //obnovi se cas
        isPaused = false;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true); //ukaze se panel escape systemu
        Time.timeScale = 0f; //zmrzne cas
        isPaused = true;
    }

    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1f; //obnovi se cas pred zmenou sceny
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
