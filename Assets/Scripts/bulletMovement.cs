using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    GameObject player;
    int destroy_timer = 60;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        destroy_timer--;
        transform.position += transform.right * Time.deltaTime * 30;

        if (destroy_timer == 0)
        {
            Destroy(gameObject);
        }
    }
}
