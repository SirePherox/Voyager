using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildController : MonoBehaviour
{
    private GameManager gameManScript;
    //private PlayerController playControlScript;
    private PlayerAnimControl myAnim;
    // Start is called before the first frame update
    private void Awake()
    {
        gameManScript = GameObject.FindGameObjectWithTag(Tags.GameMan).GetComponent<GameManager>();
 

        myAnim = GetComponent<PlayerAnimControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            print("game over");
            myAnim.Death(true);
            gameManScript.isGameOver = true;
        }
    }

}
