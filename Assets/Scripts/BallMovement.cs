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
    public float currentMagnetStrength = 0.0f;
    public float magnetStrengthIncreaseFactor = 0.2f; //the amount used to increase the magnets power


    public BallDirection ballDirection = BallDirection.Up;
    public float ballSpeed = 4.0f;
    public bool isDead = false;
    public bool hasReachedDestination = false;


    private float halfScreenWidth = 0;


    public Vector2 externalForce = Vector2.zero;


    private Rigidbody2D rigidBody2d;
    


	// Use this for initialization
	void Start () {

        rigidBody2d = this.GetComponent<Rigidbody2D>();

        halfScreenWidth = Screen.width / 2;
        

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
        float inX = Input.GetAxis("Horizontal") * magnetStrength;

        float mouseClickPosition = 0;

        if(Input.GetMouseButton(0))
        {
            mouseClickPosition = Input.mousePosition.x;

            if(mouseClickPosition > halfScreenWidth)
            {
                //right side clicked
                
                //currentMagnetStrength += magnetStrengthIncreaseFactor;
                currentMagnetStrength = Mathf.Clamp( currentMagnetStrength + magnetStrengthIncreaseFactor,0f, 0.6f);
                inX = currentMagnetStrength * magnetStrength;
            }
            else
            {
                //left side clicked
                

                currentMagnetStrength = Mathf.Clamp(currentMagnetStrength + magnetStrengthIncreaseFactor, 0f, 0.6f);
                inX = - currentMagnetStrength * magnetStrength;


            }

        }
        else
        {
            currentMagnetStrength = 0.0f;

        }

        
        Vector2 applyForce = new Vector2(inX, 0);

        externalForce = applyForce;
        
    }



}
