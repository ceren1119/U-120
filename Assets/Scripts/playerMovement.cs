/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    private float jumpPressedTime;
    private float doubleTapTimeThreshold = 1f;
    
    public float lookSpeed = 2f;
    public float lookXlimit = 45f;

    public GameObject jumpSoundSource;
    private GameObject jumpSound;
    
    Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    public bool canMove = true;
    public bool canFly = false;
    public bool isFlying = false;
    private bool isHoldingJump = false;
    public bool isDescending = false;

    private CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        //movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        
        //running
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        
        //jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
            PlayJumpSound();
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        
        //rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXlimit, lookXlimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        //flying
        isHoldingJump = Input.GetButton("Jump");
        isDescending = Input.GetButton("Crouch");

        if (canFly && isHoldingJump)
        {
            if (!isFlying)
            {
                if (Time.time - jumpPressedTime < doubleTapTimeThreshold)
                {
                    // Enable flying
                    //rb.velocity = Vector3.zero;
                    isFlying = true;
                }
                else
                {
                    jumpPressedTime = Time.time;
                }
            }
        }
        else
        {
            // Disable flying
            if (isFlying)
            {
                if (Time.time - jumpPressedTime < doubleTapTimeThreshold)
                {
                    if (isDescending)
                    {
                        // Descend
                        //rb.AddForce(Vector3.down * flyGravity, ForceMode.Acceleration);
                    }
                    else
                    {
                        // Stop flying and start falling
                        //rb.AddForce(Vector3.down * flyGravity, ForceMode.Acceleration);
                        isFlying = false;
                    }
                }
            }
        }

    }
    public void EnableFlying()
    {
        canFly = true;
        // Example: Disable gravity and enable flying animations or effects
        // rb.useGravity = false;
        //animator.SetBool("Flying", true);
    }

    public void ClearEffects()
    {
        canFly = false;
        isFlying = false;
    }
        private void PlayJumpSound()
        {
            // Instantiate the button sound source prefab if it doesn't exist
            if (jumpSound == null && jumpSoundSource != null)
            {
                jumpSound = Instantiate(jumpSoundSource, transform.position, Quaternion.identity);
            }

            // Play the button sound
            if (jumpSound != null)
            {
                AudioSource audioSource = jumpSound.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }  
        }
} */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    
    public float lookSpeed = 2f;
    public float lookXlimit = 45f;

    public GameObject jumpSoundSource;
    private GameObject jumpSound;
    
    Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    public bool canMove = true;
    public bool canFly = false;
    public bool isFlying = false;

    private CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        //movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        
        //running
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        
        //jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
            PlayJumpSound();
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        
        //rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXlimit, lookXlimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        //flying
        if (canFly && Input.GetButtonDown("Jump"))
        {
            if (!isFlying)
            {
                // Enable flying
                //rb.velocity = Vector3.zero;
                gravity = 0;
                isFlying = true;
            }
            else
            {
                // Disable flying
                //rb.AddForce(Vector3.down * flyGravity, ForceMode.Acceleration);
                gravity = 10;
                isFlying = false;
            }
        }

    }
    public void EnableFlying()
    {
        canFly = true;
        // Example: Disable gravity and enable flying animations or effects
        // rb.useGravity = false;
        //animator.SetBool("Flying", true);
    }

    public void ClearEffects()
    {
        canFly = false;
    }
        private void PlayJumpSound()
        {
            // Instantiate the button sound source prefab if it doesn't exist
            if (jumpSound == null && jumpSoundSource != null)
            {
                jumpSound = Instantiate(jumpSoundSource, transform.position, Quaternion.identity);
            }

            // Play the button sound
            if (jumpSound != null)
            {
                AudioSource audioSource = jumpSound.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }  
        }
}
