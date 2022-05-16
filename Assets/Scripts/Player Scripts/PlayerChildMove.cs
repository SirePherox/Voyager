using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    public float playerInput;
    public const float playerChangePosOffset = 5.0f;
    public const float playerPosXMax = 2.0f; //the boundaries of the players movement, left and right

    private Vector3 playerPos;
    public float distCovered;
    public bool player_Can_move;
    public bool canMoveLeft;
    public bool canMoveRight;

    public bool isGame_Over;

    private PlayerAnimControl playerAnimScript;
    private GameManager gameManScript;
    private UIManager uiManScript;


    public Vector3 instantiateOffset;

    public GameObject asteroidPrefab;
    public Vector3 asteroidPos;
    public float asteroidPosX = 2f;
    public float asteroidPosY = 5.0f;
    public float asteroidMinTime = 1.0f;
    public float asteroidmaxTime = 3.0f;


    public GameObject lavaRockPrefab;
    public Vector3 lavaRockPos;
    public float lavaRockPosX = 1.5f;
    public float lavaRockPosY = 4.0f;
    public float lavaRockMinTime = 0.5f;
    public float lavaRockMaxTime = 2.5f;

    public float currentTime;
    public float defaultTime;
    public bool timerCanRun;


    void Awake()
    {
        playerAnimScript = GetComponent<PlayerAnimControl>();
        uiManScript = GameObject.FindGameObjectWithTag("UI Manager").GetComponent<UIManager>();
        gameManScript = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        isGame_Over = false;
    }

    private void Start()
    {
        instantiateOffset = new Vector3(0, 0, 30);
        timerCanRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        //set values
        playerPos = transform.position;
        distCovered = playerPos.z; //gets distance moved by player
        uiManScript.playerDist = distCovered; //sets player z position to the variable "player dist"
        playerInput = Input.GetAxisRaw(Tags.Hor_Axis); //gets player input to allow for left & right movement
        //

        //check conditions
        if (!gameManScript.isGameOver)
        {
            player_Can_move = true;
        }
        else if (gameManScript.isGameOver)
        {
            player_Can_move = false;
            isGame_Over = true;
        }

        //game bugs , if player falls below the stage
        if (playerPos.y < -10f)
        {
            isGame_Over = true;
        }
        //

        //call functions if game is NOT over
        if (!isGame_Over)
        {
            MovePlayer();
            CanSwipe();
            InstantiateAllObstacles();
            MakeGameDifficult(distCovered); //use players dist to make game more diffficult
        }

    }

    void MovePlayer()
    {

        if (player_Can_move && !gameManScript.isGameOver)
        {
            playerAnimScript.Run(true);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

            if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W)))
            {
                playerAnimScript.Jump();
                transform.Translate(Vector3.up * Time.deltaTime * jumpForce);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.S)))
            {
                playerAnimScript.Slide();
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                playerAnimScript.ForwardFlip();
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                playerAnimScript.TwistFlip();
            }


        }

        //call functions
        MoveLeft();
        MoveRight();


    }

    private void CanSwipe()
    {
        //checks  player position
        float posX = playerPos.x;
        if (playerPos.x == 0 || playerPos.x < playerPosXMax || playerPos.x > -playerPosXMax)
        {
            canMoveLeft = true;
            canMoveRight = true;
        }
        if (playerPos.x >= playerPosXMax)
        {
            canMoveRight = false;
            canMoveLeft = true;
        }
        if (playerPos.x <= -playerPosXMax)
        {
            canMoveRight = true;
            canMoveLeft = false;
        }
    }

    private void MoveLeft()
    {
        if (!canMoveLeft)
            return;
        if (canMoveLeft)
        {
            if (playerInput == -1)
            {
                transform.Translate(Vector3.left * playerChangePosOffset * Time.deltaTime);
            }
        }
    }

    private void MoveRight()
    {
        if (!canMoveRight)
            return;
        if (canMoveRight && playerInput == 1)
        {
            transform.Translate(Vector3.right * playerChangePosOffset * Time.deltaTime);
        }
    }




    void InstantiateObstacle(GameObject obstacle, Vector3 instantiatePos, float minTime, float maxTime)
    {
        //time the instantiation
        float timeToInstantiate = Random.Range(minTime, maxTime);
        if (currentTime >= 0.0f)
        {
            timerCanRun = true;
        }

        if (timerCanRun)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0.0f)
            {
                timerCanRun = false;
                currentTime = timeToInstantiate;
                //Instantiate the obstacle
                Vector3 posToInstantiate = transform.position + (instantiatePos); //offset given pos by player positon &
                                                                                  //a little offset of Z
                Instantiate(obstacle, posToInstantiate, Quaternion.identity);
            }
        }
    }

    void InstantiateAllObstacles()
    {
        //asteroid
        asteroidPos.x = Random.Range(-asteroidPosX, asteroidPosX);
        asteroidPos.y = asteroidPosY;
        asteroidPos.z = instantiateOffset.z;
        InstantiateObstacle(asteroidPrefab, asteroidPos, asteroidMinTime, asteroidmaxTime);

        //lava rock
        lavaRockPos.x = Random.Range(-lavaRockPosX, lavaRockPosX);
        lavaRockPos.y = lavaRockPosY;
        lavaRockPos.z = instantiateOffset.z;
        InstantiateObstacle(lavaRockPrefab, lavaRockPos, lavaRockMinTime, lavaRockMaxTime);

    }

    void MakeGameDifficult(float pos)
    {
        if (pos > 10000f)
        {
            lavaRockMaxTime = 0.6f;

            asteroidmaxTime = 1.1f;

            instantiateOffset.z = 10f;
        }
        else if (pos > 8000f)
        {
            lavaRockMaxTime = 1.0f;
            lavaRockPosX = 1.2f;

            asteroidmaxTime = 1.5f;
            asteroidPosX = 1.5f;

            instantiateOffset.z = 15f;
        }
        else if (pos > 4000f)
        {
            lavaRockMaxTime = 1.5f;

            asteroidmaxTime = 2.0f;

            instantiateOffset.z = 20f;
        }
        else if (pos > 2000f)
        {
            lavaRockMaxTime = 2.0f;

            asteroidmaxTime = 2.5f;

            instantiateOffset.z = 25f;
        }

    }
}
