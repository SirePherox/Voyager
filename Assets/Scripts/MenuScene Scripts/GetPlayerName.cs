using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayerName : MonoBehaviour
{
    public string userInput;
    public InputField myField;
    // Start is called before the first frame update
    void Start()
    {
        myField = GetComponent<InputField>();
        //userInput = GetComponent<InputField>().text;
        myField.onEndEdit.AddListener(delegate { SavePlayerName(myField); });
       
    }

    private void Update()
    {
        
    }
    // Update is called once per frame
    public void SavePlayerName(InputField userInput)
    {
        var currentPlayerName = userInput.text;
        PlayerPrefs.SetString(Tags.cpName, currentPlayerName);
        Debug.Log(currentPlayerName);
    }
}
