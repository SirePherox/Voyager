using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector3 playerPos;
    public Vector3 playerLocalPos;
    public Vector3 stagePos = new Vector3(0, 0, 0);
    public GameObject stagePrefab; 
    public GameObject player;

    public bool isGameOver;

    public static GameManager gameManager;

    //public Quaternion newRotation = Quaternionublic Transform parentObject = stagePrefab.transform.parent;

   
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        playerLocalPos = player.transform.localPosition;
        
        Debug.Log(playerPos);
        Debug.Log(playerLocalPos);
       // TimerToInstantiateAsteroid();


    }

    public void InstantiateStage()
    {
        stagePos.z += 1000;
        Instantiate(stagePrefab, stagePos, Quaternion.identity);
       
    }



}
