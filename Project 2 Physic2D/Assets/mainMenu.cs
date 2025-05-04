using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

