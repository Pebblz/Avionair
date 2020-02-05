using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreCenter : MonoBehaviour
{


    public GameObject explosion;
    public GameObject Core;
    int doIexplode = 0; //if this number becomes 9 then yes, you do explode

    public GameObject lose;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            for(int i = 0; i < Core.GetComponent<Core>().pieceHolder.Count; i++)
            {
                if(!Core.GetComponent<Core>().pieceHolder[i].GetComponent<PieceCode>().isSafe)
                {
                    doIexplode++;
                }
                if(doIexplode == 9)
                {
                    lose.SetActive(true);
                    Instantiate(explosion);
                    Destroy(gameObject);
                }
                else if(i == Core.GetComponent<Core>().pieceHolder.Count - 1 && doIexplode != 9)
                {
                    doIexplode = 0;
                }
            }
        }
    }
}
