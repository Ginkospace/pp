using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketAI : Racket
{
    public Transform ball;
    protected override void Movement()
    {   if (Mathf.Abs(ball.position.y - transform.position.y) > Random.RandomRange(3,5)) // what ball distance AI need to move (3 is old)
        {   if (ball.position.y > transform.position.y) // ball is above
            {   GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * moveSpeed; } // go above
            else if (ball.position.y < transform.position.y) // ball is lower
            {   GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * moveSpeed; } // go lower
        }

        if (Input.GetKey("i")) { rb.transform.position += Vector3.up; } // ai racket up
        if (Input.GetKey("k")) { rb.transform.position += Vector3.down; } // ai racket down
    }
}
