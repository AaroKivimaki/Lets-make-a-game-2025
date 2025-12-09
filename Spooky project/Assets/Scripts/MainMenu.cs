using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int gameSceneIndex = 2;
    public void StartGame()
    {
        LoadingScreenManager.SceneTransfer.SceneToLoad = gameSceneIndex;
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
