using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator; // Reference to the Animator
    private Rigidbody2D _rb; // Reference to the Rigidbody2D


    public float walkSpeed = 5f; // Speed while walking
    public float runSpeed = 10f; // Speed while running
    public float jumpForce = 400f; // Force applied for jumping
    private float _speedX; // For movement input

    private bool isGrounded; // To detect if the player is on the ground
    private bool isJumping;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        ShowDebuging();
        HandleMovement();
        HandleAnimation();
    }

    private void HandleMovement()
    {
        // Get input
        _speedX = Input.GetAxis("Horizontal"); // Use A/D keys or arrow keys

        // Move the player horizontally
        Vector2 newPosition = new Vector2(_speedX * (IsRunning() ? runSpeed : walkSpeed), _rb.velocity.y);
        _rb.velocity = newPosition; // Update velocity for movement

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) /*&& IsGrounded()*/) // Only jump if grounded
        {
            PlayerJump();
            _rb.AddForce(new Vector2(0f, jumpForce)); // Apply an upward force for jumping
            // Set jump animation
        }
        if (!isGrounded)
            animator.SetBool("IsJumping", true);

        if (/*isJumping &&*/ IsGrounded())
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }

        // Crouching
        if (Input.GetKey(KeyCode.LeftControl) && IsGrounded())
        {
            animator.SetBool("IsCrouching", true);
        }
        else
        {
            animator.SetBool("IsCrouching", false);
        }
    }

    private void HandleAnimation()
    {
        Vector3 scale = transform.localScale;

        if (_speedX != 0)
        {
            scale.x = Mathf.Sign(_speedX);
            transform.localScale = scale;
        }

        // Set the SpeedX parameter based on the horizontal input
        animator.SetFloat("SpeedX", Mathf.Abs(_speedX));

        // Set the running state
        animator.SetBool("IsRunning", IsRunning());
    }

    private bool IsRunning()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Player is on the ground
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Player is not on the ground
        }
    }

    private bool IsGrounded()
    {
        return isGrounded; // Return the grounded status
    }

    private void PlayerJump()
    {
        _rb.AddForce(new Vector2(0f, jumpForce));
        if (!IsGrounded())
            animator.SetBool("IsJumping", true);
        else
            animator.SetBool("IsJumping", false);
    }

    private void ShowDebuging()
    {
        Debug.Log("Jumping :" + (animator.GetBool("IsJumping") ? "yes" : "no"));
        Debug.Log("Grounded: " + IsGrounded());
    }
}



/*public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D playerCollider;
    public Transform playerTransform;

    private float _speedX;
    private float _speedY;

    private bool isJumping;

    private float playerSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        _speedX = Input.GetAxis("Horizontal");
        _speedY = Input.GetAxis("Vertical");
        PlayerMovementAnimation();
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (_speedX > 0.25)
        {
            playerSpeed = animator.GetBool("IsRunning") ? 10f : 5f;
        }

        float moveX = _speedX * playerSpeed * Time.deltaTime;
        float moveY = (isJumping ? _speedY * 10f * Time.deltaTime : 0);

        playerTransform.position = new Vector2(
            playerTransform.position.x + moveX,
            playerTransform.position.y + moveY
            );
    }

    private void PlayerMovementAnimation()
    {
        animator.SetFloat("SpeedX", Mathf.Abs(_speedX));
        animator.SetFloat("SpeedY", _speedY);

        Vector3 scale = transform.localScale;

        //flipping player
        if (_speedX != 0)
        {
            scale.x = Mathf.Sign(_speedX);
            transform.localScale = scale;
        }

        //running
        if (Input.GetKey(KeyCode.LeftShift))
            animator.SetBool("IsRunning", true);
        else animator.SetBool("IsRunning", false);

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }
        if (_speedY == 0 && isJumping)
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }

        //crouching
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouching", true);
            playerCollider.offset = new Vector2(playerCollider.offset.x, 0.6f);
            playerCollider.size = new Vector2(playerCollider.size.x, 1.2f);
        }
        else
        {
            animator.SetBool("IsCrouching", false);
            playerCollider.offset = new Vector2(playerCollider.offset.x, 1f);
            playerCollider.size = new Vector2(playerCollider.size.x, 2f);
        }
    }
}*/
