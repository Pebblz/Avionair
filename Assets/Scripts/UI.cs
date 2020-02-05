using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public GameObject player;
    public GameObject pause;
    public Text livesText;
    public GameObject[] enemy;
    public GameObject[] spawners;
    public GameObject[] turrets;

    // Start is called before the first frame update
    void Start()
    {
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        livesText.text = ":0" + player.GetComponent<PlayerMovement>().lives.ToString();

        if(Input.GetKey(KeyCode.Escape))
        {
            
            pause.SetActive(true);
            player.SetActive(false);
            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            spawners = GameObject.FindGameObjectsWithTag("Spawner");
            turrets = GameObject.FindGameObjectsWithTag("Turret");
            for (int i=0; i < enemy.Length; i++)
            {
                enemy[i].GetComponent<EnemyPath>().speed = 0;
            }
            for(int i=0; i < spawners.Length; i++)
            {
                spawners[i].GetComponent<EnemySpawner>().spawnTime = 99999;
            }
            for (int i = 0; i < turrets.Length; i++)
            {
                turrets[i].GetComponent<TurretBehavior>().STOP = true;
            }
        }
    }
    
}
