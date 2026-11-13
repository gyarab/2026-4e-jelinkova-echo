using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //odejit ze hry
    public void QuitGame()
    {
        Application.Quit();
    }

    //zmena libovolne sceny
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
