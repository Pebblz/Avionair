using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCode : MonoBehaviour
{
    public GameObject attachment; //What object it is attached to
    public bool isStolen = false; //Stolen is when enemy has it
    public bool isSafe = true; //Whether or not it is actually 
    public int whatPieceAmI;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isSafe)
        { //If the piece is fine, make sure it's position & rotation is also fine
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }

        if(isStolen && attachment != null)
        { //When stolen and enemy has it, keep position with enemy
            transform.position = attachment.transform.position;
        }
        else if((isStolen && attachment == null) || (!isSafe && attachment == null))
        { //if the enemy doesn't actually exist (it probably died), just rotate in place until a player picks you up.
            transform.Rotate(new Vector3(0, 0, 1.5f));
        }

        if(!isStolen && attachment != null && !isSafe)
        { //Player has now
            transform.position = attachment.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && attachment == null)
        { //When colliding with player, sure is not currently attached to anything before picking up.
            if (!collision.gameObject.GetComponent<PlayerMovement>().isHolding)
            { //Make sure player isn't already holding anything first
                isStolen = false; //If player has touched it, no longer stolen
                attachment = collision.gameObject;
                collision.gameObject.GetComponent<PlayerMovement>().isHolding = true;
                collision.gameObject.GetComponent<PlayerMovement>().pieceHeld = whatPieceAmI;
            }
        }
    }
}
