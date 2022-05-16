using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public float playerDist;
    private int playerDistYears;
    private int lightYearsValue = GameValues.LightYearsValue;

    public GameObject gameOverUi;
    public TextMeshProUGUI playerDistText;
    public TextMeshProUGUI playerDistYearsText;
    public TextMeshProUGUI playerHighScoreText;
    public TextMeshProUGUI playerHighScoreNameText;

    //scripts references
    private PlayerChildMove playerChildScript;
    //

    private void Awake()
    {
        playerChildScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerChildMove>();
    }
    void Start()
    {
        gameOverUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //gets players dist from the player script
        playerDist = playerChildScript.distCovered;

        //call functions
        UpdateUi();
    }

    void UpdateUi()
    {
        playerDistText.text = playerDist.ToString("F2");
        //gets player dist in lightYears
        playerDistYears = (int)playerDist / lightYearsValue;
        playerDistYearsText.text = playerDistYears.ToString("F0");

        //call functions    
        DisplayHighScore();
        DisplayHighName();
    }


    private int GetHighScore()
    {
        //check if playerprefs has highscore key
        if (PlayerPrefs.HasKey(Tags.phsScore))
        {
            var phScore = PlayerPrefs.GetInt(Tags.phsScore);
            return phScore;
        }
        else
        {
            return 0;
        }
        //
    }

    private void SetHighScore(int highScoreToSet)
    {

        PlayerPrefs.SetInt(Tags.phsScore, playerDistYears);
    }

    private void DisplayHighScore()
    {
        int savedScore = GetHighScore();
        int currentScore = playerDistYears;
        if (currentScore > savedScore)
        {
            SetHighScore(currentScore);
            playerHighScoreText.text = currentScore.ToString();

            //also sets currentPlayerName to the highPlayerName
            if (PlayerPrefs.HasKey(Tags.cpName))
            {
                SetHighName(PlayerPrefs.GetString(Tags.cpName));
            }
            else
            {
                SetHighName("Anonymous");
            }
            //
        }
        else if (currentScore < savedScore)
        {
            playerHighScoreText.text = savedScore.ToString();
        }
    }

    private string GetHighName()
    {
        if (PlayerPrefs.HasKey(Tags.phsName))
        {
            string highName = PlayerPrefs.GetString(Tags.phsName);
            return highName;
        }
        else
        {
            return "Anonymous";
        }
    }
    private void SetHighName(string highNameToSet)
    {
        PlayerPrefs.SetString(Tags.phsName, highNameToSet);
    }
    private void DisplayHighName()
    {
        string nameToDisplay = GetHighName();
        playerHighScoreNameText.text = nameToDisplay;
    }

}
