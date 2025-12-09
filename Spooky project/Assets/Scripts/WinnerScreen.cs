using UnityEngine;
using UnityEngine.SceneManagement;
using static PauseMenu;

public class WinnerScreen : MonoBehaviour
{
    public GameObject winScreenUI; 

    public void ActivateWinScreen()
    {
        GameIsPaused = true;
        winScreenUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMenu() 
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(0); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
