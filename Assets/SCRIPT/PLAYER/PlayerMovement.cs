using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float movementSpeed;
    private float speedMultiplier;
    private float InputHorizontal;
    private float InputVertical;

    private Animator animator;
    string currentState;
    private string PLAYER_IDLE = "Girl_Idle_Down";
    private string PLAYER_IDLE_UP = "Girl_Idle_Up";
    private string PLAYER_IDLE_LEFT = "Girl_Idle_Left";
    private string PLAYER_IDLE_RIGHT = "Girl_Idle_Right";
    private string PLAYER_WALK_UP = "Girl_Walk_Up";
    private string PLAYER_WALK_DOWN = "Girl_Walk_Down";
    private string PLAYER_WALK_LEFT = "Girl_Walk_Left";
    private string PLAYER_WALK_RIGHT = "Girl_Walk_RIght";
    private string PLAYER_RUN_UP = "Girl_Run_Up";
    private string PLAYER_RUN_DOWN = "Girl_Run_Down";
    private string PLAYER_RUN_LEFT = "Girl_Run_Left";
    private string PLAYER_RUN_RIGHT = "Girl_Run_Right";

    float facingState;
    PlayerData playerData;



    private Vector2 movement;
    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        playerData = (PlayerData)GetComponent<PlayerData>();

        if (playerData.playerGender == 1)
        {
            PLAYER_IDLE = "Boy_Idle_Down";
            PLAYER_IDLE_UP = "Boy_Idle_Up";
            PLAYER_IDLE_LEFT = "Boy_Idle_Left";
            PLAYER_IDLE_RIGHT = "Boy_Idle_Right";
            PLAYER_WALK_DOWN = "Boy_Walk_Down";
            PLAYER_WALK_UP = "Boy_Walk_Up";
            PLAYER_WALK_LEFT = "Boy_Walk_Left";
            PLAYER_WALK_RIGHT = "Boy_Walk_Right";
            PLAYER_RUN_UP = "Boy_Run_Up";
            PLAYER_RUN_DOWN = "Boy_Run_Down";
            PLAYER_RUN_LEFT = "Boy_Run_Left";
            PLAYER_RUN_RIGHT = "Boy_Run_Right";
        }
    }
    void Update()
    {
        InputHorizontal = Input.GetAxisRaw("Horizontal");
        InputVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedMultiplier = 1.5f;
        }
        else
        {
            speedMultiplier = 1.0f;
        }
    }

    private void FixedUpdate()
    {
        if (InputHorizontal != 0)
        {
            rb.velocity = new Vector2(InputHorizontal * movementSpeed * speedMultiplier, 0);
            if (InputHorizontal > 0)
            {
                if (speedMultiplier == 1.5f)
                {
                    changeAnimationState(PLAYER_RUN_RIGHT);
                }
                else
                {
                    changeAnimationState(PLAYER_WALK_RIGHT);
                }
                facingState = 1;
            }
            if (InputHorizontal < 0)
            {
                if (speedMultiplier == 1.5f)
                {
                    changeAnimationState(PLAYER_RUN_LEFT);
                }
                else
                {
                    changeAnimationState(PLAYER_WALK_LEFT);
                }
                facingState = -1;
            }
        }
        else if (InputVertical != 0)
        {
            rb.velocity = new Vector2(0, InputVertical * movementSpeed * speedMultiplier);
            if (InputVertical > 0)
            {
                if (speedMultiplier == 1.5f)
                {
                    changeAnimationState(PLAYER_RUN_UP);
                }
                else
                {
                changeAnimationState(PLAYER_WALK_UP);
                }
                facingState = 2;
            }
            if (InputVertical < 0)
            {
                if (speedMultiplier == 1.5f)
                {
                    changeAnimationState(PLAYER_RUN_DOWN);
                }
                else
                {
                    changeAnimationState(PLAYER_WALK_DOWN);
                }
                facingState = 0;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            if (facingState == 0)
            {
                changeAnimationState(PLAYER_IDLE);
            }
            if (facingState == 1)
            {
                changeAnimationState(PLAYER_IDLE_RIGHT);
            }
            if (facingState == -1)
            {
                changeAnimationState(PLAYER_IDLE_LEFT);
            }
            if (facingState == 2)
            {
                changeAnimationState(PLAYER_IDLE_UP);
            }
        }
    }

    private void changeAnimationState(string NewState)
    {
        if (currentState == NewState) return;

        animator.Play(NewState);

        currentState = NewState;
    }
}
