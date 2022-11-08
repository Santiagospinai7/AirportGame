using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

public class PhotonPlayerController : MonoBehaviour
{
    // For Player Variables

    // For Player Component

    private PlayerMovementController pController;

    // For Other Game Objects 



    // Awake is called before the first frame update
    void Awake()
    {
        pController = GetComponent<PlayerMovementController>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {

        pController.MovePlayer(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        Debug.DrawLine(transform.position, transform.position + new Vector3(0, -0.01f, 0), Color.blue);

        if (Physics.Linecast(transform.position, transform.position + new Vector3(0, -0.01f, 0)))
        {
            // trigger landing
            //pController.an_Player.SetTrigger("Landing");
        }

        // check if top arrow and bottom arrow or left arrow and right arrow are pressed .. if pressed by keyboard move Player

        if (Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f)
        {

            // Move Player
            pController.MovePlayer(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        }
        else {
            pController.isStatic();
            //Debug.Log("Is not moving");
        }

        // Click Space to Jump

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pController.Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            pController.RunDown();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            pController.RunUp();
        }
    }

}
