using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public int jump = 7;
    public int moveForce = 3;
    int jumpPadPower = 15;

    bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var hor = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(hor, 0) * moveForce);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity += Vector2.up * jump;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;

        if(collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().Lose();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Teleporter"))
        {
            FindObjectOfType<GameManager>().Win();
        }
        if (collision.gameObject.name.Contains("JumpPad"))
        {
            rb.velocity += Vector2.up * jumpPadPower;
        }
    }
}
