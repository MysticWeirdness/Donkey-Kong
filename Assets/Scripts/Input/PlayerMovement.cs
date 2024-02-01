using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputControls controls;
    private Rigidbody2D rb;

    private float movSpeed = 2f;
    public bool onLadder = false;
    public bool touchingLadder = false;
    private float ladderSpeed = 0.1f;
    private void Awake()
    {
        controls = new InputControls();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 movement = controls.Controller.Movement.ReadValue<Vector2>();
        Vector2 horizontalMovement = new Vector2(movement.x, 0);
        rb.velocity = horizontalMovement * movSpeed;

        if (onLadder)
        {
            rb.gravityScale = 0;
        }
        else if (!onLadder)
        {
            rb.gravityScale = 1;
        }

        if (touchingLadder && !onLadder && controls.Controller.Interact.ReadValue<float>() == 1f)
        {
            onLadder = true;
        }
        else if (touchingLadder && onLadder && controls.Controller.Interact.ReadValue<float>() == 1f)
        {
            onLadder = false;
        }
        if (onLadder && movement.y > 0f)
        {
            transform.position += Vector3.up * ladderSpeed;
        }
        else if(onLadder && movement.y < 0f)
        {
            transform.position += Vector3.down * ladderSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            touchingLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            touchingLadder = false;
            onLadder = false;
        }
    }
}
