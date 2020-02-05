using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;

    public float spawnTime = 1;

    public float difficultyTimer = 120;

    public int spawnpicker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }

        if(spawnTime < 0)
        {
            spawnTime = 0;
        }

        if(difficultyTimer > 0)
        {
            difficultyTimer -= Time.deltaTime;
        }

        if(difficultyTimer < 0)
        {
            difficultyTimer = 0;
        }


        spawnpicker = Random.Range(1, 5);
        switch(spawnpicker)
        {
            case 1:
                if (spawnTime == 0)
                {
                    Instantiate(enemy, transform.position, transform.rotation);
                    enemy.GetComponent<EnemyPath>().transform.localScale = new Vector3(1f, 1f, 1f);
                    enemy.GetComponent<EnemyPath>().speed = 2;
                    enemy.GetComponent<EnemyPath>().health = 2;
                    spawnTime = 3;
                }
                break;

            case 2:
                if (spawnTime == 0 && difficultyTimer <= 0)
                {
                    Instantiate(enemy, transform.position, transform.rotation);
                    enemy.GetComponent<EnemyPath>().transform.localScale = new Vector3(2f, 2f, 2f);
                    enemy.GetComponent<EnemyPath>().speed = 2;
                    enemy.GetComponent<EnemyPath>().health = 4;
                    spawnTime = 3;
                }
                break;

            case 3:
                if (spawnTime == 0 && difficultyTimer <= 60)
                {
                    Instantiate(enemy, transform.position, transform.rotation);
                    enemy.GetComponent<EnemyPath>().speed = 4;
                    enemy.GetComponent<EnemyPath>().transform.localScale = new Vector3(1f, 1f, 1f);
                    enemy.GetComponent<EnemyPath>().health = 2;
                    spawnTime = 3;
                }
                break;
        }
        
    }
}
