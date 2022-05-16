using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public GameObject helpUi;
    public GameObject creditsUi;

    [SerializeField]
    private GameObject progressPanel;
    [SerializeField]
    private Slider progressSlider;
    [SerializeField]
    private TextMeshProUGUI progressValue;

    //script references
    private SoundManager soundScript;

    private void Awake()
    {
        progressPanel.SetActive(false);
        soundScript = GetComponent<SoundManager>();
    }
    private IEnumerator LoadLevelAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);
            progressSlider.value = progress;
            progressValue.text = (progress * 100).ToString("F0") + "%";


            yield return null;
        }
    }
    public void StartGame(int sceneIndex)
    {
        //play click sound
        soundScript.PlayClickFx();
        //
        progressPanel.SetActive(true);
        StartCoroutine(LoadLevelAsync(sceneIndex));
    }
    public void helpUi_On()
    {
        //play click sound
        soundScript.PlayClickFx();
        //
        helpUi.SetActive(true);
    }
    public void helpUi_Off()
    {
        //play click sound
        soundScript.PlayClickFx();
        //
        helpUi.SetActive(false);
    }
    public void creditsUi_On()
    {
        //play click sound
        soundScript.PlayClickFx();
        //
        creditsUi.SetActive(true);
    }
    public void creditsUi_Off()
    {
        //play click sound
        soundScript.PlayClickFx();
        //
        creditsUi.SetActive(false);
    }
    public void QuitGame()
    {
        //play click sound
        soundScript.PlayClickFx();
        //
        Application.Quit();
    }

    public void ResetGame()
    {
        //play click sound
        soundScript.PlayClickFx();
        //checks and deletes playerprefs
        PlayerPrefs.DeleteAll();
        //reload scene
        SceneManager.LoadScene(GameValues.MenuScene_Index);
    }


}
