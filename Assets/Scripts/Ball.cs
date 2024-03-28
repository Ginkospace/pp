using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Racket racket;
    public Rigidbody2D ballRb;
    public Racket LeftRacket, RightRacket;
    public float moveSpeed, moveSpeedAdder=0.1f;

    void Start() { ballRb.velocity = new Vector2(1, 1) * moveSpeed; } // start velocity

    #region unfixedBug_ballStop
    //void FixedUpdate()
    //{ if (ballRb.velocity.x<0.2&&ballRb.velocity.x > -0.2) {ballRb.velocity.x = Random.Range(-5,5);}}
    #endregion unfixedBug_ballStop

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TagMenager tagMenager = collision.gameObject.GetComponent<TagMenager>(); // collision tag

        //if (tagMenager == null){ return; }
        Tag tag = tagMenager.wallTag;

        if (tag.Equals(Tag.leftWall)){ RightRacket.GetScore();}
        if (tag.Equals(Tag.rightWall)){ LeftRacket.GetScore();}
        if (tag.Equals(Tag.leftRacket)){ ballGo(collision, 1);}
        if (tag.Equals(Tag.rightRacket)){ ballGo(collision, -1);}

        GetComponent<AudioSource>().Play(); // play sound
    }

    private void ballGo(Collision2D collision, int x) // change ball when collision
    {   //moveSpeed++; // add 1 speed every times // old code
        //if (moveSpeed < 15) {} // old bug, ball glitch through walls
        moveSpeed = moveSpeed + moveSpeedAdder; // add x speed to ball speed every times
        //racket.Instance.moveSpeed = racket.Instance.moveSpeed + racket.Instance.moveSpeedAdder; // add x speed to racket speed every times
        ballRb.velocity = new Vector2(x, transform.position.y - collision.gameObject.transform.position.y / collision.collider.bounds.size.y) * moveSpeed; // get velocity
    }
}
