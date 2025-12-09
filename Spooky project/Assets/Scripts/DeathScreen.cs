using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject deathScreenUI;
    private const int LOADING_SCENE_INDEX = 1;

    public void ActivateDeathScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        deathScreenUI.SetActive(true);
        
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadingScreenManager.SceneTransfer.SceneToLoad = currentSceneIndex;

        SceneManager.LoadScene(LOADING_SCENE_INDEX);
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