using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    float screen_height;
    float screen_width;
    float timer = 2;
    public Transform enemyPrefab;
    public BossActions bossPrefab;

    public static EnemySpawner Instance;

    BossActions boss;

    public enum Status
    {
        Active,
        NotActive
    }

    public Status myStatus = Status.Active;


    public void CreateBoss()
    {
        Vector3 bossPosition = new Vector3(screen_width, Random.Range(-screen_height, screen_height), 0);
        boss = Instantiate<BossActions>(
            bossPrefab,
            bossPosition,
            transform.rotation);
        boss.Setup(this);
        Debug.Log("boss spawner");
    }

    // Use this for initialization
    void Start()
    {
        Instance = this;
        Camera camera = Camera.main;
        screen_height = camera.orthographicSize;
        screen_width = screen_height * camera.aspect;

    }

    // Update is called once per frame
    void Update()
    {
        if (myStatus == Status.Active)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {

                Vector3 enemyPosition = new Vector3(screen_width, Random.Range(-screen_height, screen_height), 0);
                Instantiate(
                     enemyPrefab,
                     enemyPosition,
                     transform.rotation);

                timer = 2;

            }
        }

    }

    public void StopSpawner()
    {
        myStatus = Status.NotActive;
    }

}

