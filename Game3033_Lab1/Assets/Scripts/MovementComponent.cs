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

    PlayerController playerController;
    Rigidbody rigidbody;

    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

     
        if (!(inputVector.magnitude > 0)) moveDirection = Vector3.zero;

        moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;
        float currentSpeed = playerController.isRunning ? runsSpeed : walkSpeed;

        Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);
        transform.position += movementDirection;

    }
    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();



    }

    public void OnRun(InputValue value)
    {

        playerController.isRunning = true;

    }


    public void OnJump(InputValue value)
    {

        if (playerController.isJumping) return;
        
        playerController.isJumping = true;
            rigidbody.AddForce((transform.up + moveDirection) * jumpForce, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !playerController.isJumping) return;

        playerController.isJumping = false;
    }
}
