using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {


    private string myTag;

    void Start()
    {
        myTag = gameObject.tag;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        string colliderTag = collider.tag;

        if(myTag.Equals("Finish") && colliderTag.Equals("Player"))
        {
            //the ball has reached the finish red hole. The Player Has won

            //Debug.Log("WINNER!!!");

            return;
        }

        if(colliderTag.Equals("Player"))
        {
            //the player has hit an obstacle
            //Debug.Log("HIT!!!");

        }
    }


     

}
