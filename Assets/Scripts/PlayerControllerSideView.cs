using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSideView : MonoBehaviour
{
    public CharacterController characterController;
    private Vector3 movementVector = Vector3.zero;
    private Vector3 inputVector = Vector3.zero;
    private Vector3 jumpVelocity = Vector3.zero;

    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheck;

    public float playerSpeed = 3.0f;
    public float walkingSpeed = 1.0f;
    public float jumpHeight = 1.0f;
    public float gravity = -20.0f;
    public float groundDistance = 0.4f;

    public bool isGrounded;
    public bool isWalking;
    public bool isJumping;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMovement();

        CheckIfGrounded();

        PlayerJump();
    }

    private void PlayerMovement()
    {
        inputVector.x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isWalking = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isWalking = false;
        }

        movementVector = Vector3.ClampMagnitude(transform.forward * inputVector.x, 1.0f);

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
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && jumpVelocity.y < 0)
        {
            jumpVelocity.y = -2f;
        }
    }

    private void PlayerJump()
    {
        bool isTryingJump = Input.GetKeyDown(KeyCode.Space);

        if (isTryingJump && isGrounded)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

        if (isJumping)
        {
            jumpVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            isGrounded = false;
        }

        jumpVelocity.y += gravity * Time.deltaTime;
        characterController.Move(jumpVelocity * Time.deltaTime);
    }
}
