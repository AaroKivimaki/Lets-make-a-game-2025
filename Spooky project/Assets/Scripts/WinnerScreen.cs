using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerScreen : MonoBehaviour
{
    public GameObject winScreenUI; 

    public void ActivateWinScreen()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        winScreenUI.SetActive(true);
    }

    public void LoadMenu() 
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(1); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
