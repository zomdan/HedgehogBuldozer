using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

// VARIABLES!!!
    [SerializeField] private float dashSpeed = 10f;  // how fast are we?
    private bool isDashing = false;  // are we dashing right now?
    [SerializeField] private Rigidbody2D rb;  // rigidbodyyy
     [SerializeField] private GameObject deathScreen;  // the thing that tells u when u died
     [SerializeField] private GameObject winScreen; //same as previous but for winning
     [SerializeField] private Animator playerAnimator;   
    private Vector2 dashDirection; 

//START FIELD
    void Start()
    {
        // Start with no velocity
        rb.velocity = Vector2.zero;
    }

//UPDATE FIELD
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))  // right
        {
            isDashing = true;
            dashDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))  // left
        {
            isDashing = true;
            dashDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.W))  // up
        {
            isDashing = true;
            dashDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))  // down
        {
            isDashing = true;
            dashDirection = Vector2.down;
        }

        // Setting the velocity
        if (isDashing)
        {
            rb.velocity = dashDirection * dashSpeed;
        }

        if (playerAnimator.GetInteger("die") == 2)
        {
            StartCoroutine(DeathSequence());
        }
    }

//COLLIDER FIELD
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // u hit smth
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Trap2") || collision.gameObject.CompareTag("Trap1"))
        {
            stopMoving();
            ContactPoint2D contact = collision.contacts[0];
            transform.position += (Vector3)contact.normal * 0.1f;
        }  

        if (collision.gameObject.CompareTag("Trap2"))
        {
            playerAnimator.SetInteger("die", 2);
        }

        if (collision.gameObject.CompareTag("Trap1"))
        {
            playerAnimator.SetInteger("die", playerAnimator.GetInteger("die") + 1);
        }
    }

//TRIGGER FIELD
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            playerAnimator.SetBool("win", true);
            StartCoroutine(WinSequence());
        }
    }

//METHODS!!!
    private void stopMoving()
    {
            isDashing = false;
            rb.velocity = Vector2.zero; // no more velocity for you buddy sorry
    }

    private IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(1f);

        // ITS TIME TO DIE!!
        Time.timeScale = 0;
        deathScreen.SetActive(true);
    }

    private IEnumerator WinSequence()
    {
        yield return new WaitForSeconds(1f);

        // ITS TIME TO WIN!!
        Time.timeScale = 0;
        winScreen.SetActive(true);
    }
}
