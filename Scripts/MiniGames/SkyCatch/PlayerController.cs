using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float horizontalBoundary = 4.5f;
    private bool isFacingRight = false; // Add this variable

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(moveInput, 0);
        GetComponent<Rigidbody2D>().velocity = moveDirection * speed;

        // Get the player's position in world coordinates
        Vector3 playerPos = Camera.main.WorldToViewportPoint(transform.position);

        // Restrict the player's X position to stay within the camera bounds
        playerPos.x = Mathf.Clamp(playerPos.x, 2.0f, 90.0f);

        // Convert the restricted position back to world coordinates
        transform.position = Camera.main.ViewportToWorldPoint(playerPos);

        
        /*/ Check if the right button is clicked
        if (Input.GetButtonDown("horizontal.Negative")) // Change "Fire1" to the actual button name if needed
        {
            // Rotate the player 180 degrees
            RotatePlayer();
        }*/

        if (moveInput < 0)
        {
            // Rotate the player 180 degrees if not already facing left
            if (!isFacingRight)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                isFacingRight = true;
            }
        }
        else if (moveInput > 0)
        {
            // Rotate the player 0 degrees if not already facing right
            if (isFacingRight)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                isFacingRight = false;
            }
        }
    }
    
    


     /*/ Add a method to rotate the player 180 degrees
    private void RotatePlayer()
    {
        if (isFacingRight)
        {
            // Rotate to face left
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isFacingRight = false;
        }
        else
        {
            // Rotate to face right
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isFacingRight = true;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CollectibleItem"))
        {
            // Handle collecting items (e.g., increase score)
            Destroy(collision.gameObject);
            GameManagerSC.Instance.UpdateScore(10); // Adjust the points as needed
        }
        else if (collision.CompareTag("Obstacle"))
        {
            // Handle hitting obstacles (e.g., decrease score, game over)
            Destroy(collision.gameObject);
            GameManagerSC.Instance.UpdateScore(-5); // Adjust the points as needed
        
        }
    }
}
