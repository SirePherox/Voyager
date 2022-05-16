using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayerName : MonoBehaviour
{
       
    public string userInput;

 
    public void SavePlayerName(string s)
    {
        userInput = s;
        PlayerPrefs.SetString(Tags.cpName, userInput);
        Debug.Log(userInput);
    }
}
