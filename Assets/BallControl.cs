using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
 
    public float xInitialForce;
    public float yInitialForce;

    void ResetBall()
    {
        transform.position = Vector2.zero;

        rigidBody2D.velocity = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
 
        Invoke("PushBall", 2);
    }

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();    
        RestartGame();
    }

    void Update()
    {
        
    }
    
    void PushBall()
    {
        rigidBody2D.AddForce(new Vector2(-xInitialForce, yInitialForce));
    }
}
