using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour {

    public LevelLoader levelLoader;

    private bool handleInput = true;

    // Play button function. Should load the next scene, character select screen, or whatever.
    public void PlayButton(string sceneName) {
        // Disallow button function while loading.
        if (!handleInput) {
            return;
        }

        // Loads the "Game"scene.
        levelLoader.LoadLevel(sceneName);
    }

    // Quit button function.
    public void QuitButton() {
        Application.Quit();
        Debug.Log("Quit Button Pressed.");
    }
}
