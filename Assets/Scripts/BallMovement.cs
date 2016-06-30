using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

    public enum BallDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public float magnetStrength = 0.5f;
    public BallDirection ballDirection = BallDirection.Up;
    public float ballSpeed = 4.0f;
    public bool isDead = false;
    public bool hasReachedDestination = false;

    public Vector2 externalForce = Vector2.zero;


    private Rigidbody2D rigidBody2d;
    


	// Use this for initialization
	void Start () {

        rigidBody2d = this.GetComponent<Rigidbody2D>();
        

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        HandleInput();

        Movement(externalForce);        

	}

    Vector2 GetVelocity()
    {

        Vector2  y;

        switch(ballDirection)
        {
            case BallDirection.Up:
                y = Vector2.up * ballSpeed;
                break;

            case BallDirection.Down:
                y = Vector2.down * ballSpeed;
                break;
            default:
                y = Vector2.up * ballSpeed;
                break;

        }
        

        return y;


    }



    public void Movement(Vector2 externalForce)
    {
        Vector2 getVelocity = GetVelocity();
        
        Vector2 applyForce = ( externalForce + getVelocity ) * Time.deltaTime;

        rigidBody2d.AddForce(applyForce );
        


    }

  

    public void HandleInput()
    {
        var inX = Input.GetAxis("Horizontal") * magnetStrength;

        
        Vector2 applyForce = new Vector2(inX, 0);

        externalForce = applyForce;
        
    }



}
