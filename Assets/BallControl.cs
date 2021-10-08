using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;
 
    // Besarnya gaya awal yang diberikan untuk mendorong bola
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

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();    
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void PushBall()
    {
        rigidBody2D.AddForce(new Vector2(-xInitialForce, yInitialForce));
    }
}
