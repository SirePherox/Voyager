using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildController : MonoBehaviour
{
    private GameManager gameManScript;
    private PlayerController playControlScript;
    private PlayerAnimControl myAnim;
    // Start is called before the first frame update
    private void Awake()
    {
        gameManScript = GameObject.FindGameObjectWithTag(Tags.GameMan).GetComponent<GameManager>();
 
        playControlScript = GetComponentInParent<PlayerController>();

        myAnim = GetComponent<PlayerAnimControl>();
    }

    // Update is called once per frame
    void Update()
    {
        playControlScript.childTransform = transform.position;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Stage_Collider))
        {
            gameManScript.InstantiateStage();
            print("collider");

            //transform.position.x += 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            print("game over");
            myAnim.Death(true);
            gameManScript.isGameOver = true;
        }
    }

    public void ResetPosScript_off()
    {
        playControlScript.canResetPos = false;
    }

    public void ResetPosScript_on()
    {
        playControlScript.canResetPos = true;
    }
}
