using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(.2f, .5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * speed; //Diagonal movement
        transform.position += -transform.right * Time.deltaTime * speed;

        if(transform.position.x < -20 && transform.position.y > 20)
        {
            transform.position = new Vector3(Random.Range(4f, 26f), -20f, 0);
            float scale = Random.Range(.4f, 2f);
            transform.localScale = new Vector3(scale, scale, scale);
            speed = Random.Range(.2f, .5f);
        }
    }
}
