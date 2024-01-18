using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    //[SerializeField] float walkSpeed = 6.0f;
    //[SerializeField] float sprintSpeed = 8.0f;
    [SerializeField] float gravity = -13.0f;
    float velocityY = 0.0f;

    Rigidbody rb;
    StaminaBar st;

    CharacterController controller = null;
    //public CharacterController controller;
    float standingHeight;
    public float crouchingHeight = 0.5f;

    

    
    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    

    [Header("Keybinds")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        st = GetComponent<StaminaBar>();
        
        standingHeight = controller.height;

        moveSpeed = walkSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    void UpdateMovement()
    {
        Vector2 inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputDir.Normalize();

        if (controller.isGrounded)
            velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * inputDir.y + transform.right * inputDir.x) * moveSpeed;

        controller.Move(velocity * Time.deltaTime);

        print("Walking");

        // start sprinting
        if(Input.GetKeyDown(sprintKey))
        {
            if (st.stamina != 0)
                moveSpeed = sprintSpeed;

            print("Sprinting");
        }


        // stop sprinting
        if(Input.GetKeyUp(sprintKey))
        {
            moveSpeed = walkSpeed;

            print("Walking");
        }

        if(st.stamina <=0)
        {
            moveSpeed = walkSpeed;
        }

    }
}
