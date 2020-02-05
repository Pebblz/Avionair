using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 5;
    public float lives = 3;
    public float invisTime = 0;
    public float iframes = 0;
    public SpriteRenderer seeing;
    public PolygonCollider2D epicCollider;
    public GameObject boom;

    public GameObject lose;
    public GameObject explosion;

    public bool isHolding = false; //Whether or not player hold piece
    public bool isFrozen = false;

    public int pieceHeld; //what piece it is holding

    private void Start()
    {
        lose.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (isFrozen == false)
        { 
        //This messy looking if statement is just taking account the combination of buttons, yes this looks kinda bad.
        if (Input.GetButton("Left") || Input.GetButton("Right") || Input.GetButton("Up") || Input.GetButton("Down"))
        {
            if (Input.GetButton("Right") && Input.GetButton("Down"))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270 + 45));
            }
            else
            {
                if (Input.GetButton("Right") && Input.GetButton("Up"))
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));

                }
                else
                {
                    if (Input.GetButton("Left") && Input.GetButton("Down"))
                    {
                        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180 + 45));
                    }
                    else
                    {
                        if (Input.GetButton("Left") && Input.GetButton("Up"))
                        {
                            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 135));
                        }
                        else
                        {
                            if (Input.GetButton("Left"))
                            {
                                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                            }

                            if (Input.GetButton("Right"))
                            {
                                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                            }

                            if (Input.GetButton("Up"))
                            {
                                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                            }

                            if (Input.GetButton("Down"))
                            {
                                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
                            }
                        }
                    }
                }
            }

            transform.position += transform.right * Time.deltaTime * speed;
        }
    }

        if(invisTime > 0)
        {
            invisTime -= Time.deltaTime;
        }

        if(invisTime < 0)
        {
            iframes = 2;
            invisTime = 0;
        }

        if(invisTime == 0)
        {
            seeing.enabled = true;
            isFrozen = false;
        }
        else
        {
            epicCollider.enabled = false;
            seeing.enabled = false;
            isFrozen = true;
        }


        if(iframes > 0)
        {
            iframes -= Time.deltaTime;
        }

        if(iframes < 0)
        {
            iframes = 0;
        }

        if(iframes == 0)
        {
            epicCollider.enabled = true;
        }


        if(lives == 0)
        {
            lose.SetActive(true);
            invisTime = 99999;
            iframes = 99999;
        }

        if(lives < 0)
        {
            invisTime = 99999;
            iframes = 99999;
            lives = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(boom, transform.position, transform.rotation);
            isFrozen = true;
            Destroy(collision.gameObject);
            seeing.enabled = false;
            lives--;
            invisTime = 2;
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
