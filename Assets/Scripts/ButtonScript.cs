using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject pause;
    public GameObject player;
    public GameObject[] enemy;
    public GameObject[] spawners;
    public GameObject[] turrets;
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

   public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Resume()
    {
        pause.SetActive(false);
        player.SetActive(true);
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        turrets = GameObject.FindGameObjectsWithTag("Turret");

        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<EnemyPath>().speed = 2;
        }

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].GetComponent<EnemySpawner>().spawnTime = 2;
        }

        for (int i = 0; i < turrets.Length; i++)
        {
            turrets[i].GetComponent<TurretBehavior>().STOP = false;
        }


    }
}
