using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed, walkSpeed, runSpeed, crouchSpeed, rotationSpeed, climbingSpeed , ActiveClimbingSpeed;
    public bool walkCheck, runCheck, crouchCheck ;
    public float moveY2;
    public bool ladderDismountTriggerBool , RayCheck;
    public Vector3 moveDirection, moveVertical;
    public Vector3 dismountPosition;
    public Vector3 velocity;
    public bool isGrounded, ladderCheck, ladderDismountCheck;
    public float gravity, jumpHeight;
    public float groundCheckDistance, ladderCheckDistance;
    public LayerMask groundMask, ladderMask, ladderDismountMask , ladderRayMask, deleteColLayer;
    public GameObject[] ladder; 
    public GameObject ladCol;
    public Level2Manager Gm;


    public CharacterController controller;
    public Animator anim;



    public void Start()
    {
        controller = GetComponent<CharacterController>();
        Check();
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("Ladder", false);
        ladderDismountTriggerBool = true;
        RayCheck = false;
       
    }

    public void Update()
    {
        if (Gm.playerOnLight && !Gm.playerBehindCart)
        {
            //dead
            Gm.playerDead();
            
     

        }
        else if(Gm.playerIsAlive)
        {
            Move();
            ladderAnimationTrigger();


            ////////////////////////////////////////////[Ray Do Not/////////////////////////////////////////////////////////
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 0.69f, ladderRayMask))
            {
                Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
                RayCheck = true;
            }

            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * 0.69f, Color.green);
                RayCheck = false;
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
         
        }
    
    
    }
    
    public void Check()
    {
        walkCheck = true;
        runCheck = true;
        crouchCheck = true;
    }

    public void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position,groundCheckDistance,groundMask);
        ladderCheck = Physics.CheckSphere(transform.position, ladderCheckDistance, ladderMask);
        ladderDismountCheck = Physics.CheckSphere(transform.position, ladderCheckDistance, ladderDismountMask);
        if(isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Hover");
        //moveY2 = moveY * climbingSpeed;
        
        moveDirection = new Vector3(moveX, 0, moveZ);
        moveVertical = new Vector3(0, moveY, 0);
        moveDirection.Normalize();

        if (!ladderCheck)
        {
            if (isGrounded)
            {

                Rotation();

                if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
                {
                    Walk();
                }

                else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
                {
                    Run();
                }

                else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftControl))
                {
                    Crouch();
                }

                else if (moveDirection == Vector3.zero)
                {
                    Idle();
                }


                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }

                if (Input.GetKeyDown("e") && moveDirection == Vector3.zero)
                {   
                    //anim.SetLayerWeight(anim.GetLayerIndex("InteractLayer"), 1);
                    anim.SetTrigger("Interact");
                    //yield return new WaitForSeconds(0.9f);
                    //anim.SetLayerWeight(anim.GetLayerIndex("InteractLayer"), 0);
                }
            }
            moveDirection *= moveSpeed;
            controller.Move(moveDirection * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            Invoke("ladderCheckDistanceInvoke", 0.5f);

        }
        else if (ladderCheck) 
        { 
            ClimbLadder();
        }

    }



    public void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed",1.0f,0.11f,Time.deltaTime);
    }

    public void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1.5f, 0.15f, Time.deltaTime);
    }

    public void Crouch()
    {
        moveSpeed = crouchSpeed;
        anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }

    public void Idle()
    {
        moveSpeed = 0;
        anim.SetFloat("Speed", 0.5f, 0.21f, Time.deltaTime);
    }

    public void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetTrigger("Jump");
    }

    


    public void Rotation()
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            this.gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }
    }

    public void ClimbLadder()
    { 
        if(!ladderDismountCheck )
        {
            if (moveDirection == Vector3.zero )
            {
                Idle();
            }
            if (!Input.GetKey("a") && !Input.GetKey("d") && !Input.GetKey("s") && RayCheck)
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetKey("e"))
                {
                    anim.SetFloat("LadderSpeed", 0.0f, 0.1f, Time.deltaTime);
                }
                else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey("q"))
                {
                    anim.SetFloat("LadderSpeed", 1.0f, 0.1f, Time.deltaTime);
                }
                else
                {
                    anim.SetFloat("LadderSpeed", 0.5f, 0.1f, Time.deltaTime);
                }
            }
            else if (isGrounded)
            {
                ladderCheckDistance = 0;
            }
            moveVertical *= climbingSpeed;
            controller.Move(moveVertical * Time.deltaTime);
        }
        else if(ladderDismountCheck)
        {
            ladderDismountTrigger();
        }


    }

    public void ladderCheckDistanceInvoke()
    {
        ladderCheckDistance = 0.7f;
        
    }


    public void disableLadder()
    {
        ladCol.SetActive(false);
    }

     public void enableLadder()
    {
        ladCol.SetActive(true);
    }











    public void ladderAnimationTrigger()
    {
        if(ladderCheck)
        {
            anim.SetBool("Ladder", true);
        }
        if(!ladderCheck)
        {
            anim.SetBool("Ladder", false);
        }
    }

    public void ladderDismountTrigger()
    {
        anim.SetTrigger("LadderDismount");
        if(ladderDismountTriggerBool==true)
        {
            Invoke("ladderDismountTransformInvoke", 2.99f);
            ladderDismountTriggerBool = false;
            Invoke("ladderDismountBoolInvoke", 6f);
            ladder[0].SetActive(false);
        }
       
    }

    public void ladderDismountTransformInvoke()
    {
        
        dismountPosition = this.transform.position;
        Debug.Log(dismountPosition);
        anim.SetTrigger("LadderClimbed");
        
        dismountPosition += new Vector3(1.0f, 1.5948261f, 0.72021362f);

        
    }
    public void ladderDismountBoolInvoke()
    {
        ladderDismountTriggerBool = true;
        // this.transform.position = dismountPosition;
        
    }



}
