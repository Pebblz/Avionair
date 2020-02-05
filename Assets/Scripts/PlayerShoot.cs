using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    int bullet_timer = 0;
    bool is_shoot = false;
   

    //public AudioSource shooting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Update for button important button presses
    private void Update()
    {
        if (GetComponent<PlayerMovement>().invisTime <= 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                is_shoot = true;
            }

            if (Input.GetKeyUp(KeyCode.Z))
            {
                bullet_timer = 0;
                is_shoot = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (is_shoot == true)
        {
            bullet_timer--;
            if (bullet_timer <= 0)
            {
                bullet_timer = 8;
                Instantiate(bullet);
                //shooting.Play();
            }
        }
    }
}
