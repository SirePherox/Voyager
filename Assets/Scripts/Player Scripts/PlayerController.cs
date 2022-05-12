using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 2f;

    private Vector3 playerPos;
    public bool player_Can_move;
    //public bool player_Can_;
    private PlayerAnimControl playerAnimScript;
    // Start is called before the first frame update
    void Awake()
    {
        playerPos = transform.localPosition;
        playerAnimScript = GetComponentInChildren<PlayerAnimControl>();
    }

    private void Start()
    {
        player_Can_move = true;
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        
        if (player_Can_move)
        {
            playerAnimScript.Run(true);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

            if(Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W)))
            {
                playerAnimScript.Jump();
                transform.Translate(Vector3.up * Time.deltaTime * jumpForce);
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.S)))
            {
                playerAnimScript.Slide();
            }
        }
       
    }
}
