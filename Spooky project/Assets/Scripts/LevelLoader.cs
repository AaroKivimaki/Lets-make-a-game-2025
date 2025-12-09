using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{ 
    public static class SceneTransfer

    {
        public static int SceneToLoad = 2;
    }

    public Slider progressSlider;
    public float minLoadTime = 1.0f;
    public void Start()
    {
        Time.timeScale = 1f;
        // Aloita scenen lataaminen taustalla
        StartCoroutine(LoadSceneAsync(SceneTransfer.SceneToLoad));
    }

    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        float startTime = Time.time;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if (progressSlider != null)
            {
                progressSlider.value = Mathf.Lerp(progressSlider.value, progress, Time.deltaTime * 5f);
            }
            if (operation.progress >= 0.9f && progressSlider.value >= 0.99f && (Time.time - startTime >= minLoadTime))
            {
                // Aseta slideri 100% visuaalisesti
                if (progressSlider != null)
                {
                    progressSlider.value = 1f; 
                }

                // Annetaan pieni viive 100% näkymiselle
                yield return new WaitForSeconds(0.2f); 
                
                // Vasta nyt sallitaan scenen vaihtuminen
                operation.allowSceneActivation = true;
            }
            
            yield return null;
        }
    }
}
