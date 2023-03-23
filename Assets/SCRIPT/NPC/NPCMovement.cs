using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool isCorutineLooping;

    public float stillTime;

    public float movementSpeed;
    private float InputHorizontal;
    private float InputVertical;

    public enum direction {
        stay, up, down, left, right
    };

    public direction firstMoveDir;
    public direction SecondMoveDir;
    public direction ThirdMoveDir;
    public direction FourthMoveDir;


    public float firstTimeDelay;
    public float secondTimeDelay;
    public float thirdTimeDelay;
    public float fourthTimeDelay;

    public string NPC_Idle_Down;
    public string NPC_Idle_Up;
    public string NPC_Idle_Left;
    public string NPC_Idle_Right;
           
    public string NPC_Walk_Down;
    public string NPC_Walk_Up;
    public string NPC_Walk_Left;
    public string NPC_Walk_Right;

    private Animator animator;
    string currentState;

    float facingState;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isCorutineLooping = true;
        StartCoroutine(movementPlay());
    }

    IEnumerator movementPlay()
    {

        while (isCorutineLooping) {
            yield return new WaitForSeconds(stillTime);
            if (firstMoveDir == direction.left || firstMoveDir == direction.right)
            {
                if (firstMoveDir == direction.right)
                {
                    InputHorizontal = 1;
                }
                else if(firstMoveDir == direction.left)
                {
                    InputHorizontal = -1;
                }
                rb.velocity = new Vector2(InputHorizontal * movementSpeed, 0);
                checkWalkAnimation();
            }

            if (firstMoveDir == direction.up || firstMoveDir == direction.down)
            {
                if (firstMoveDir == direction.up)
                {
                    InputVertical = 1;
                }
                else if(firstMoveDir == direction.down)
                {
                    InputVertical = -1;
                }
                rb.velocity = new Vector2(0, InputVertical * movementSpeed);
                checkWalkAnimation();
            }
            if (firstMoveDir == direction.stay)
            {
                InputHorizontal = 0;
                InputVertical = 0;
                rb.velocity = Vector2.zero;
                checkFacingState();
            }

            yield return new WaitForSeconds(firstTimeDelay);

            InputHorizontal = 0;
            InputVertical = 0;
            rb.velocity = Vector2.zero;
            checkFacingState();

            yield return new WaitForSeconds(stillTime);

            if (SecondMoveDir == direction.left || SecondMoveDir == direction.right)
            {
                if (SecondMoveDir == direction.right)
                {
                    InputHorizontal = 1;
                }
                else if(SecondMoveDir == direction.left)
                {
                    InputHorizontal = -1;
                }
                rb.velocity = new Vector2(InputHorizontal * movementSpeed, 0);
                checkWalkAnimation();
            }

            if (SecondMoveDir == direction.up || SecondMoveDir == direction.down)
            {
                if (SecondMoveDir == direction.up)
                {
                    InputVertical = 1;
                }
                else if(SecondMoveDir == direction.down)
                {
                    InputVertical = -1;
                }
                rb.velocity = new Vector2(0, InputVertical * movementSpeed);
                checkWalkAnimation();
            }
            if (SecondMoveDir == direction.stay)
            {
                InputHorizontal = 0;
                InputVertical = 0;
                rb.velocity = Vector2.zero;
                checkFacingState();
            }
            yield return new WaitForSeconds(secondTimeDelay);

            InputHorizontal = 0;
            InputVertical = 0;
            rb.velocity = Vector2.zero;
            checkFacingState();

            yield return new WaitForSeconds(stillTime);

            if (ThirdMoveDir == direction.left || ThirdMoveDir == direction.right)
            {
                if (ThirdMoveDir == direction.right)
                {
                    InputHorizontal = 1;
                }
                else if(ThirdMoveDir == direction.left)
                {
                    InputHorizontal = -1;
                }
                rb.velocity = new Vector2(InputHorizontal * movementSpeed, 0);
                checkWalkAnimation();
            }

            if (ThirdMoveDir == direction.up || ThirdMoveDir == direction.down)
            {
                if (ThirdMoveDir == direction.up)
                {
                    InputVertical = 1;
                }
                else if(ThirdMoveDir == direction.down)
                {
                    InputVertical = -1;
                }
                rb.velocity = new Vector2(0, InputVertical * movementSpeed);
                checkWalkAnimation();
            }
            if (ThirdMoveDir == direction.stay)
            {
                InputHorizontal = 0;
                InputVertical = 0;
                rb.velocity = Vector2.zero;
                checkFacingState();
            }

            yield return new WaitForSeconds(thirdTimeDelay);

            InputHorizontal = 0;
            InputVertical = 0;
            rb.velocity = Vector2.zero;
            checkFacingState();

            yield return new WaitForSeconds(stillTime);
            if (FourthMoveDir == direction.left || FourthMoveDir == direction.right)
            {
                if (FourthMoveDir == direction.right)
                {
                    InputHorizontal = 1;
                }
                else if(FourthMoveDir == direction.left)
                {
                    InputHorizontal = -1;
                }
                rb.velocity = new Vector2(InputHorizontal * movementSpeed, 0);
                checkWalkAnimation();
            }

            if (FourthMoveDir == direction.up || FourthMoveDir == direction.down)
            {
                if (FourthMoveDir == direction.up)
                {
                    InputVertical = 1;
                }
                else if(FourthMoveDir == direction.down)
                {
                    InputVertical = -1;
                }
                rb.velocity = new Vector2(0, InputVertical * movementSpeed);
                checkWalkAnimation();
            }

            if (FourthMoveDir == direction.stay)
            {
                InputHorizontal = 0;
                InputVertical = 0;
                rb.velocity = Vector2.zero;
                checkFacingState();
            }


            yield return new WaitForSeconds(fourthTimeDelay);

            InputHorizontal = 0;
            InputVertical = 0;
            rb.velocity = Vector2.zero;
            checkFacingState();
        }
    }
    private void changeAnimationState(string NewState)
    {
        if (currentState == NewState) return;

        animator.Play(NewState);

        currentState = NewState;
    }

    private void checkFacingState()
    {
        if (facingState == 0)
        {
            changeAnimationState(NPC_Idle_Down);
        }
        if (facingState == 1)
        {
            changeAnimationState(NPC_Idle_Right);
        }
        if (facingState == -1)
        {
            changeAnimationState(NPC_Idle_Left);
        }
        if (facingState == 2)
        {
            changeAnimationState(NPC_Idle_Up);
        }
    }

    private void checkWalkAnimation()
    {
        if (InputHorizontal > 0)
        {
            changeAnimationState(NPC_Walk_Right);
            
            facingState = 1;
        }
        if (InputHorizontal < 0)
        {
            changeAnimationState(NPC_Walk_Left);

            facingState = -1;
        }
        if (InputVertical > 0)
        {
            changeAnimationState(NPC_Walk_Up);

            facingState = 2;
        }
        if (InputVertical < 0)
        {
            changeAnimationState(NPC_Walk_Down);

            facingState = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCorutineLooping = false;
            rb.velocity = Vector2.zero;
            checkFacingState();
        }
            
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
        isCorutineLooping = true;
    }
}
