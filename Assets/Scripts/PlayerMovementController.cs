using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    // For Player Variables

    public float currentMoveSpeed;
    public float moveSpeed;
    public Vector3 velocity;
    public float currentWalkAnimationSpeed;
    public float walkAnimationSpeed;
    public float rotationSpeed;
    public float jumpForce;
    public float runSpeed;
    public float runAnimationSpeed;

    private bool isJumping;
    private bool isWalking;
    private bool isGrounded;

    // For Player Component

    private Rigidbody rb_Player;
    public Animator an_Player;
    private PhotonView pView;

    // For Other GameObjects

    private GameObject cameraObj;
    public GameObject playerMesh;


    // Awake is called before the first frame update
    void Awake()
    {

        rb_Player = GetComponent<Rigidbody>();
        an_Player = GetComponent<Animator>();
        pView = GetComponent<PhotonView>();
        cameraObj = Camera.main.gameObject;

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {



    }


    // Move Function For Move Player

    public void MovePlayer(float forward, float right)
    {

        if (pView.IsMine)
        {

            Vector3 translation;

            translation = forward * cameraObj.transform.forward;
            translation += right * cameraObj.transform.right;
            translation.y = 0;


            // check if vertical and horizontal pressed

            if (translation.magnitude > 0.2f)
            {
                // set velocity to equal to translation
                velocity = translation;
            }
            else
            {
                // set velocity to zero
                velocity = Vector3.zero;
            }


            // Move Player By Rigidbody Velocity

            rb_Player.velocity = new Vector3(velocity.normalized.x * moveSpeed, rb_Player.velocity.y, velocity.normalized.z * moveSpeed);
            //Debug.Log(rb_Player.velocity);

            /*
            if (rb_Player.velocity.y > 5)
            {
                an_Player.SetBool("isFalling", true);
                an_Player.SetBool("isWalking", false);
            } else if (rb_Player.velocity.y < 0.001 && rb_Player.velocity.y > -0.1)
            {
                an_Player.SetBool("isGrounded", true);
            } else if (rb_Player.velocity.y == 0)
            {
                an_Player.SetBool("isWalking", true);
            }
            */

            
            if (rb_Player.velocity.y == 0) 
            {
                isJumping = false;
            }
            

            // Rotate Player

            if (velocity.magnitude > 0.2f)
            {
                transform.rotation = Quaternion.Lerp(playerMesh.transform.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * rotationSpeed);
            }

            // Move Animation

            an_Player.SetBool("isWalking", true);
        }
    }

    public void isStatic()
    {
        if (!isJumping) 
        {
            an_Player.SetBool("isWalking", false);
        }
        
    }


    // Start Jump Function

    public void Jump()
    {

        if (pView.IsMine)
        {
            // jump by rigidbody addforce
            Debug.Log("JUMP");
            isJumping = true;
            rb_Player.AddForce(Vector3.up * jumpForce);
        }

    }

    public void RunDown()
    {

        if (pView.IsMine)
        {
            moveSpeed = runSpeed;
        }

    }

    public void RunUp()
    {

        if (pView.IsMine)
        {
            moveSpeed = currentMoveSpeed;
        }

    }
}
