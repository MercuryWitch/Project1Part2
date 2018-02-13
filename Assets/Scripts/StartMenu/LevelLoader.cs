using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI loadingBarProgressText;

    public void LoadLevel (string sceneName) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        StartCoroutine(LoadAsynchronously(sceneName));
        
    }

    // Loading bar coroutine.
    IEnumerator LoadAsynchronously(string sceneName) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // Make the load screen the active screen.
        loadingScreen.SetActive(true);

        while (!operation.isDone) {
            Debug.Log(operation.progress);

            slider.value = operation.progress;
            loadingBarProgressText.text = operation.progress * 100f + "%";
            yield return null;
        }
    }
}
