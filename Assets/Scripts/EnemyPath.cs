using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPath : MonoBehaviour
{

    //  public Rigidbody2D rb;
    public float speed = 3;
    public GameObject boom;
    public GameObject player;
    public GameObject core;
    public GameObject explosion;
    private Waypoints Wp;
    private Waypoints Bp;
    private Waypoints Gp;
    private int waypointIndex;
    private int bluepointIndex;
    private int greenpointIndex;
    public bool redpath;
    public bool bluepath;
    public bool greenpath;
    private bool reversal;
    private bool breversal;
    private bool greversal;


    int buildindex;

    public float health = 2;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        buildindex = currentscene.buildIndex;

        if (redpath)
        {
            reversal = false;
            Wp = GameObject.FindGameObjectWithTag("Waypoint").GetComponent<Waypoints>();
        }

        if (bluepath)
        {
            Bp = GameObject.FindGameObjectWithTag("Bluepoint").GetComponent<Waypoints>();
            breversal = false;
        }

        if (greenpath)
        {
            Gp = GameObject.FindGameObjectWithTag("Greenpoint").GetComponent<Waypoints>();
            greversal = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (buildindex == 0)
        {
            //boom.SetActive(false);

            if (redpath)
            {
                reversal = false;
                if (waypointIndex == Wp.waypoints.Length - 1)
                {
                    Destroy(gameObject);
                }
            }

            if (bluepath)
            {
                breversal = false;
                if (bluepointIndex == Bp.waypoints.Length - 1)
                {
                    Destroy(gameObject);
                }
            }

            if (greenpath)
            {
                greversal = false;
                if (greenpointIndex == Gp.waypoints.Length - 1)
                {
                    Destroy(gameObject);
                }
            }
        }
       
            // move to those waypoints

            if (redpath)
            {


                Vector3 direction = Wp.waypoints[waypointIndex].position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                transform.position = Vector2.MoveTowards(transform.position, Wp.waypoints[waypointIndex].position, speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, Wp.waypoints[waypointIndex].position) < 0.1f)
                {

                    if (waypointIndex == Wp.waypoints.Length - 1)
                    {
                        reversal = true;
                    }

                    if (waypointIndex == 0 && reversal)
                    {
                        //Instantiate(boom, transform.position, transform.rotation);
                        Destroy(gameObject);
                    }

                    if (waypointIndex < Wp.waypoints.Length - 1 && !reversal)
                    {
                        waypointIndex++;
                    }
                    else if (waypointIndex > 0 && reversal)
                    {
                        waypointIndex--;
                    }
                }
            }

            if (bluepath)
            {

                Vector3 direction = Bp.bluepoints[bluepointIndex].position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                transform.position = Vector2.MoveTowards(transform.position, Bp.bluepoints[bluepointIndex].position, speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, Bp.bluepoints[bluepointIndex].position) < 0.1f)
                {

                    if (bluepointIndex == Bp.bluepoints.Length - 1)
                    {
                        breversal = true;
                    }

                    if (bluepointIndex == 0 && breversal)
                    {
                       // Instantiate(boom, transform.position, transform.rotation);
                        Destroy(gameObject);
                    }

                    if (bluepointIndex < Bp.bluepoints.Length - 1 && !breversal)
                    {
                        bluepointIndex++;
                    }
                    else if (bluepointIndex > 0 && breversal)
                    {
                        bluepointIndex--;
                    }
                }
            }

            if (greenpath)
            {

                Vector3 direction = Gp.greenpoints[greenpointIndex].position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                transform.position = Vector2.MoveTowards(transform.position, Gp.greenpoints[greenpointIndex].position, speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, Gp.greenpoints[greenpointIndex].position) < 0.1f)
                {

                    if (greenpointIndex == Gp.greenpoints.Length - 1)
                    {
                        greversal = true;
                    }

                    if (greenpointIndex == 0 && greversal)
                    {
                       // Instantiate(boom, transform.position, transform.rotation);
                        Destroy(gameObject);
                    }

                    if (greenpointIndex < Gp.greenpoints.Length - 1 && !greversal)
                    {
                        greenpointIndex++;
                    }
                    else if (greenpointIndex > 0 && greversal)
                    {
                        greenpointIndex--;
                    }
                }
            }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            if (--health <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Instantiate(boom, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

}
