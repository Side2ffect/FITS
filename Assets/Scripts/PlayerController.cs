using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    private Vector3 movementVector = Vector3.zero;
    private Vector3 inputVector = Vector3.zero;
    private Vector3 jumpVelocity = Vector3.zero;
    public GameObject SideViewCam;
    public Transform playerCharacter;

    //[SerializeField] LayerMask groundMask;
    //[SerializeField] Transform groundCheck;

    private float playerSpeed = 3.0f;
    private float walkingSpeed = 1.0f;
    private float gravity = -15.0f;
    //private float jumpHeight = 1.0f;
    //private float groundDistance = 0.4f;
    public float knockbackForce = 1.5f;

    private bool isWalking;
    public bool isGrounded;
    //private bool isJumping;
    private bool isSideView;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        CheckCurrentCamera();

        PlayerMovement();

        CheckIfGrounded();

        PlayerJump();

        SetPlayerRotation();
    }

    private void CheckCurrentCamera()
    {
        if(SideViewCam.activeSelf)
        {
            isSideView = true;
        }
        else
        {
            isSideView = false;
        }
    }

    private void PlayerMovement()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isWalking = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isWalking = false;
        }

        if (isSideView == true)
        {

            movementVector = Vector3.ClampMagnitude(transform.forward * inputVector.x, 1.0f);
        }
        else
        {
            movementVector = Vector3.ClampMagnitude(transform.right * inputVector.x + transform.forward * inputVector.z, 1.0f);
        }

        if (isWalking)
        {
            characterController.Move(walkingSpeed * Time.deltaTime * movementVector);
        }
        else
        {
            characterController.Move(playerSpeed * Time.deltaTime * movementVector);
        }
    }

    private void CheckIfGrounded()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    
        if (jumpVelocity.y < 0)
        {
            jumpVelocity.y = -2f;
        }
    }

    private void PlayerJump()
    {
        //bool isTryingJump = Input.GetKeyDown(KeyCode.Space);
        //
        //if (isTryingJump && isGrounded)
        //{
        //    isJumping = true;
        //}
        //else
        //{
        //    isJumping = false;
        //}
        //
        //if (isJumping)
        //{
        //    jumpVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
        //    isGrounded = false;
        //}
    
        jumpVelocity.y += gravity * Time.deltaTime;
        characterController.Move(jumpVelocity * Time.deltaTime);
    }

    private void SetPlayerRotation()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            playerCharacter.rotation = Quaternion.Euler(0f, -90.0f, 0f);
        }
    }
}
