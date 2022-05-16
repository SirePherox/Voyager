using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 2f;
    public float playerInput;
    public const float playerChangePosOffset = 5.0f;

    private Vector3 playerPos;
    public bool player_Can_move;
    public bool canMoveLeft;
    public bool canMoveRight;

    public bool canResetPos;

    private PlayerAnimControl playerAnimScript;
    private GameManager gameManScript;
    public Vector3 childTransform;

    // Start is called before the first frame update

    public float posX = 2f;
    public float asteroidPosY = 3.0f;
    public float asteriodZOffset = 15.0f;

    public float currentTime;
    public float defaultTime;
    public bool timerCanRun;

    public Vector3 asteroidPos;
    public GameObject asteroidPrefab;
    void Awake()
    {
        playerAnimScript = GetComponentInChildren<PlayerAnimControl>();
        childTransform = GetComponentInChildren<Transform>().position;
        gameManScript = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        canResetPos = true;
    }

    private void Start()
    {
        currentTime = 2.0f;
    }
    // Update is called once per frame
    void Update()
    {
        playerPos = transform.position;

        playerInput = Input.GetAxisRaw(Tags.Hor_Axis);

        if (!gameManScript.isGameOver)
        {
            player_Can_move = true;
        }

        //call functions
        MovePlayer();
        CanSwipe();
        ResetPos();
        //TimerTo
        TimerToInstantiateAsteroid();

        Debug.Log("The child" + childTransform);
    }

    void MovePlayer()
    {

        if (player_Can_move)
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
        if (playerPos.x == 0)
        {
            canMoveLeft = true;
            canMoveRight = true;
        }
        else if (playerPos.x >= 2)
        {
            canMoveRight = false;
            canMoveLeft = true;
        }
        else if (playerPos.x <= -2)
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
                Debug.Log("pressed left");
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
            print("pressed right");
        }
    }

    void ResetPos()
    {
        if (canResetPos)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            childTransform = new Vector3(transform.position.x, 0f, transform.position.z);
        }
    }

    public void InstantiateAsteroid()
    {
        asteroidPos.z = asteriodZOffset;
        asteroidPos.y = asteroidPosY;
        asteroidPos.x = Random.Range(-posX, posX);
        Instantiate(asteroidPrefab, childTransform + transform.TransformPoint(asteroidPos), Quaternion.identity);
    }

    void TimerToInstantiateAsteroid()
    {
        if (currentTime >= 0.0f)
            timerCanRun = true;
        defaultTime = Random.Range(0.2f, 2.5f);
        if (timerCanRun)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0.0f)
            {
                timerCanRun = false;
                InstantiateAsteroid();
                currentTime = defaultTime;
            }
        }

    }
}
