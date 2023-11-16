using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public int jump = 7;
    public int moveForce = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var hor = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(hor, 0) * moveForce);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * jump;
        }
    }
}
