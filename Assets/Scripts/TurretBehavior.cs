using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{

    public Queue<GameObject> enemies;
    public GameObject bullet;
    public int cool_down;
    private int init_cool_down;
    private bool isFiring = false;
    public float speed;
    public bool STOP = false;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new Queue<GameObject>();
        init_cool_down = cool_down;
    }

    // Update is called once per frame
    void Update()
    {
        //so the turrets won't cool down when paused
        if (!STOP)
        {
            if (--cool_down == 0)
            {
                isFiring = true;
                cool_down = init_cool_down;


            }
        }
    }
    private void FixedUpdate()
    {
        if (isFiring == true && !STOP)
        {

            if (enemies.Count > 0 && enemies.Peek() != null)
            {
                var b = Instantiate(bullet) as GameObject;
                b.transform.position = this.transform.position;
                b.GetComponent<TurretBulletMovement>().enemy = enemies.Peek();

                isFiring = false;
            }
            else
            {
                if (enemies.Count > 0)
                    enemies.Dequeue();

            }

        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Enemy")
        {
            enemies.Enqueue(collision.gameObject);
        }
    }


}
