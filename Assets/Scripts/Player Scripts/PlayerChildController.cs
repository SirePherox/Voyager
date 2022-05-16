using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildController : MonoBehaviour
{
    //THE SCRIPT "PLAYERCONTROLLER" IS NOT USED BY ANY GAMEOBJECT
    //not PLAYERCHILDCONTROLLER
    private GameManager gameManScript;
    
    private PlayerAnimControl myAnim;
    // Start is called before the first frame update
    private void Awake()
    {
        gameManScript = GameObject.FindGameObjectWithTag(Tags.GameMan).GetComponent<GameManager>();


        myAnim = GetComponent<PlayerAnimControl>();
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Stage_Collider))
        {
            gameManScript.InstantiateStage();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.Obstacle_Tag))
        {
            myAnim.Death(true);
            gameManScript.isGameOver = true;
        }
    }

}
