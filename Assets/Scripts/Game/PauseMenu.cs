using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public string sceneName;
    public GameObject pauseMenuUI;
    public LevelLoader levelLoader;

    public static bool gameIsPaused = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Escape pressed.");
            if (gameIsPaused) {
                Debug.Log("Resume called.");
                ResumeGame();
            } else {
                Debug.Log("Pause called.");
                PauseGame();
            }
        }
    }

    public void ResumeGame() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    private void PauseGame() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu(string sceneName) {
        Time.timeScale = 1f;
        gameIsPaused = false;
        levelLoader.LoadLevel(sceneName);
    }

    public void QuitGame() {
        Debug.Log("Quit Button Pressed.");
        Application.Quit();
    }
}
