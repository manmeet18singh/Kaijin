using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 6f;

    public float turnSmoothTime = 1f;
    float turnSmoothVelo;
    public float speedSmoothTime = 1.1f;
    float speedSmoothVelo; 
    float currentSpeed;

    Animator animator;

    Transform cameraT;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        cameraT = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
       Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       Vector2 inputDir = input.normalized;

        if(inputDir != Vector2.zero){
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation,ref turnSmoothVelo, turnSmoothTime);
        }

        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running)?runSpeed:walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelo, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World); 

        float animationSpeedPercent = ((running)?1:.5f) * inputDir.magnitude;
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

    }
}
