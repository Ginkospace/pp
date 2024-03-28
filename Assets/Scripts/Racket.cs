using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Racket : MonoBehaviour
{
    public Racket Instance; // to call up while use
    public Rigidbody2D rb;
    public string AxesName;
    public float moveSpeed, moveSpeedAdder = 0.1f; // the speed all racket up and down 
    public int Score { get; private set; }
    public Text scoreText;

    void FixedUpdate()
    {   Movement(); // run their movement C# (what AI or human)
        
        if (Input.GetKey("u")) { rb.transform.position += Vector3.up; } // all racket up
        if (Input.GetKey("j")) { rb.transform.position += Vector3.down; } // all racket down
    }
    protected abstract void Movement(); // their movement C# (what AI or human)
    public void GetScore() { Score++; scoreText.text = Score.ToString(); } // update score

}
