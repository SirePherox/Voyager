using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
  

    public Vector3 stagePos = new Vector3(0, 0, 0);

    public GameObject stagePrefab;
    public GameObject pauseUi;

    public bool isGameOver;
    public bool isGamePaused;

    public float timeToWait = 3f; //time to wait before calling game over
    //script references
    private UIManager uiManScript;
    private SoundManager soundScript;

    private void Awake()
    {
        uiManScript = GameObject.FindGameObjectWithTag("UI Manager").GetComponent<UIManager>();
        soundScript = GetComponent<SoundManager>();
    }
    void Start()
    {
        isGameOver = false;
        isGamePaused = false;
        pauseUi.SetActive(false);

        //make sure time scale is normal
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //check conditions

        //call functions
        GameIsOver();
    }

    public void InstantiateStage()
    {
        stagePos.z += 1000;
        Instantiate(stagePrefab, stagePos, Quaternion.identity);
       
    }

    public void PauseGame()
    {
        //play click sound
        soundScript.PlayClickFx();
        //
        if (!isGameOver) //enable player to pause if game is NOT over already
        {
            Time.timeScale = 0;
            pauseUi.SetActive(true);
            isGamePaused = true;
        }

    }

    public void ResumeGame()
    {
        //play click sound
        soundScript.PlayClickFx();
        //
        Time.timeScale = 1;
        pauseUi.SetActive(false);
        isGamePaused = false;
    }

    public void TryAgain()
    {
        //play click sound
        soundScript.PlayClickFx();
        //
        SceneManager.LoadScene(GameValues.GameScene_Index);
    }

    public void GoToMenu()
    {
        //play click sound
        soundScript.PlayClickFx();
        //
        SceneManager.LoadScene(GameValues.MenuScene_Index);
    }

    private void GameIsOver()
    {
        if (isGameOver)
        {
                //
        }
    }


}
