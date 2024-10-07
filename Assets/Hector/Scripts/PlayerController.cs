using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


 [RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float jumpheight = 1.9f;
    public float gravityScale = -20f;
    Vector3 moveInput = Vector3.zero;
    CharacterController characterController;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        
    }
    private void Update()
    {
        Move();

    }
    private void Move()
    {
        if (characterController.isGrounded) 
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveInput = transform.TransformDirection(moveInput) * walkSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                moveInput.y = Mathf.Sqrt(jumpheight * -2f * gravityScale);


            }
            characterController.Move(moveInput * Time.deltaTime);

        }
       
    }
}
