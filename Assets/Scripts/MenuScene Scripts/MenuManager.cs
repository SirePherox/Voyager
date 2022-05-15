using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public GameObject helpUi;
    public GameObject creditsUi;

    //script references
    private SoundManager soundScript;

    private void Awake()
    {
        soundScript = GetComponent<SoundManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void StartGame()
    {
        //play click sound
        soundScript.PlayClickFx();
        //
        SceneManager.LoadScene(GameValues.GameScene_Index);
    }


}
