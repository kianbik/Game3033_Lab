using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MovementComponent : MonoBehaviour
{

    [SerializeField]
    float walkSpeed = 5.0f;
    [SerializeField]
    float runsSpeed = 10.0f;
    [SerializeField]
    float jumpForce = 5.0f;


    //Components
    PlayerController playerController;
    Rigidbody rigidbody;
    Animator animator;




    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;


    public readonly int movementXHash = Animator.StringToHash("MovementX");
    public readonly int movementYHash = Animator.StringToHash("MovementY");
    public readonly int isJumpingHash = Animator.StringToHash("IsJumping");
    public readonly int isRunningHash = Animator.StringToHash("IsRunning");
    public readonly int isAimingHash = Animator.StringToHash("IsAiming");

    // Start is called before the first frame update
    void Start()
    { animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (playerController.isJumping) return;
        if (!(inputVector.magnitude > 0)) moveDirection = Vector3.zero;

        moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;
        float currentSpeed = playerController.isRunning ? runsSpeed : walkSpeed;

        Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);
        transform.position += movementDirection;

    }
    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();

        animator.SetFloat(movementXHash, inputVector.x);
        animator.SetFloat(movementYHash, inputVector.y);

    }

    public void OnRun(InputValue value)
    {
      
            playerController.isRunning = value.isPressed;
            animator.SetBool(isRunningHash, playerController.isRunning);
       
    }

    public void OnAim(InputValue value)
    {

        playerController.isAiming = value.isPressed;
        animator.SetBool(isAimingHash, playerController.isAiming);

    }


    public void OnJump(InputValue value)
    {

        if (playerController.isJumping) return;
        
        playerController.isJumping = true;
            rigidbody.AddForce((transform.up + moveDirection) * jumpForce, ForceMode.Impulse);
        animator.SetBool(isJumpingHash, playerController.isJumping);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !playerController.isJumping) return;

        playerController.isJumping = false;
        animator.SetBool(isJumpingHash, false);
    }
}
