using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 6f;
    public float gravity = -12f;
    public float turnSmoothTime = 1f;
    float turnSmoothVelo;
    public float speedSmoothTime = 1.1f;
    float speedSmoothVelo; 
    float currentSpeed;
    public float jumpHeight = 1f;
    [Range(0,1)]
    public float airControl;
    float velocityY;

    Animator animator;
    Transform cameraT;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        cameraT = Camera.main.transform;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // input
       Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       Vector2 inputDir = input.normalized;
       bool running = Input.GetKey (KeyCode.LeftShift);
       move(inputDir, running);

        if (Input.GetKeyDown (KeyCode.Space)) {
            jump();
        }

        // animator
        float animationSpeedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * .5f);
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

    }

    void move(Vector2 inputDir, bool running) {
        
        if(inputDir != Vector2.zero){
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation,ref turnSmoothVelo,getModSmoothTime(turnSmoothTime));
        }

        float targetSpeed = ((running)?runSpeed:walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelo, getModSmoothTime(speedSmoothTime));

        velocityY += Time.deltaTime * gravity;
        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY; 
        controller.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

        if (controller.isGrounded) {
            velocityY = 0;
        }
    }

    void jump() {
        if (controller.isGrounded) {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
        }
    }

    float getModSmoothTime(float smoothTime) {
        if (controller.isGrounded) {
            return smoothTime;
        }
        if (airControl == 0) {
            return float.MaxValue;
        }
        return smoothTime / airControl;
    }
}
