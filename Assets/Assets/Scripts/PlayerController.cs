using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1 , 2
//0.6 , 1.2

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D playerCollider;

    private float _speedX;
    private float _speedY;

    // Update is called once per frame
    void Update()
    {
        _speedX = Input.GetAxis("Horizontal");
        _speedY = Input.GetAxis("Vertical");

        Vector3 scale = transform.localScale;

        animator.SetFloat("SpeedX", Mathf.Abs(_speedX));
        animator.SetFloat("SpeedY", _speedY);

        if (Input.GetKey(KeyCode.LeftShift))
            animator.SetBool("IsRunning", true);
        else animator.SetBool("IsRunning", false);

        /*if (Input.GetKey(KeyCode.Space))
            animator.SetBool("IsJumping", true);
        else animator.SetBool("IsJumping", false);*/

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouching", true);
            playerCollider.offset = new Vector2(playerCollider.offset.x, 0.6f);
            playerCollider.size = new Vector2(playerCollider.size.x, 1.2f);
        }
        else
        {
            playerCollider.offset = new Vector2(playerCollider.offset.x, 1f);
            playerCollider.size = new Vector2(playerCollider.size.x, 2f);
            animator.SetBool("IsCrouching", false);
        }
        if (_speedX < 0 && scale.x == 1)
            scale.x *= -1;

        else if (_speedX > 0 && scale.x == -1)
            scale.x *= -1;

        transform.localScale = scale;
    }
}
