using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{

    public GameObject piece1rb;
    public GameObject piece2rb;
    public GameObject piece3rb;
    public GameObject piece4rb;
    public GameObject piece5rb;
    public GameObject piece6rb;
    public GameObject piece7rb;
    public GameObject piece8rb;
    public GameObject piece9rb;
    public List<GameObject> pieceHolder;
    public CircleCollider2D maincollider;

    public float rotation1;
    private Quaternion jeff;

    public int pieces = 1;
    // Start is called before the first frame update
    void Start()
    {
        pieceHolder = new List<GameObject>();

        pieceHolder.Add(piece1rb); //Adding Pieces to the list
        pieceHolder.Add(piece2rb);
        pieceHolder.Add(piece3rb);
        pieceHolder.Add(piece4rb);
        pieceHolder.Add(piece5rb);
        pieceHolder.Add(piece6rb);
        pieceHolder.Add(piece7rb);
        pieceHolder.Add(piece8rb);
        pieceHolder.Add(piece9rb);

        for (int i = 0; i < pieceHolder.Count; i++)
        { //Telling each piece, who they are.
            pieceHolder[i].GetComponent<PieceCode>().whatPieceAmI = i;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        { //When Enemy collides
            for (int i = 0; i < pieceHolder.Count; i++)
            {
                if (pieceHolder[i].GetComponent<PieceCode>().isSafe == true)
                { //Loop through pieces and check if they are actually okay or not. The first one you run into that is doing is fine is now no longer fine. NotSafe NotSafe.
                    pieceHolder[i].GetComponent<PieceCode>().isSafe = false;
                    pieceHolder[i].GetComponent<PieceCode>().attachment = collision.gameObject;
                    pieceHolder[i].GetComponent<PieceCode>().isStolen = true;
                    break;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { //When Player Collides
            if (collision.gameObject.GetComponent<PlayerMovement>().isHolding == true)
            { //Check if player is holding something, if yes, take the piece it is holding and welcome it back home.
                pieceHolder[collision.gameObject.GetComponent<PlayerMovement>().pieceHeld].GetComponent<PieceCode>().isSafe = true;
                collision.gameObject.GetComponent<PlayerMovement>().isHolding = false; // Be sure to tell the player that they don't actually have anything.
            }
        }
    }
}
