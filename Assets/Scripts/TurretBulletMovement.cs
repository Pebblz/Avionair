using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletMovement : MonoBehaviour
{
    int destroy_timer = 60;
    private Transform end;
    public float speed;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(enemy.transform);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.rotation = Quaternion.Euler(transform.rotation.x,
            transform.rotation.y, 0);
        speed = 15;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.forward * speed);
        //transform.position += transform.right * Time.deltaTime * speed;
        
        if (--destroy_timer == 0)
        {
            Destroy(gameObject);
        }
    }
}
