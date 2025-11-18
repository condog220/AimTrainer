using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Transform orientation;

    public float horizontalInput;
    public float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput();
        
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void moveInput()
    {
        if(GameModeSelect.currentMode is Strafing)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }
    }

    private void movePlayer()
    {
        moveDirection = orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

    }
}
