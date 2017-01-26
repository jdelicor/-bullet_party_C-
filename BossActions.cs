using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActions : MonoBehaviour
{


    private int EnemyHealth = 30;

    public GameObject bullet_boss_Prefab;

    public float timer = 2f;

    public BossEnemyStatus myStatusBoss = BossEnemyStatus.Alive;


    public enum BossEnemyStatus
    {
        Alive,
        Explonding,
        Dead
    }


    public bool Move = true;    ///gives you control in inspector to trigger it or not
    public Vector3 MoveVector = Vector3.up; //unity already supplies us with a readonly vector representing up and we are just chaching that into MoveVector
    public float MoveRange = 2.0f; //change this to increase/decrease the distance between the highest and lowest points of the bounce
    public float MoveSpeed = 0.5f; //change this to make it faster or slower

    private BossActions bounceObject; //for caching this transform

    //Largura visual do sprite;
    public float VisualWidth;

    EnemySpawner enemySpawner;

    Vector3 startPosition; //used to cache the start position of the transform
    void Start()
    {
        bounceObject = this;
        startPosition = bounceObject.transform.position;

    }

    public void Setup(EnemySpawner _enemySpawner)
    {
        this.enemySpawner = _enemySpawner;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet_prefab")
        {
            EnemyHealth -= 10;
            other.gameObject.SetActive(false);

            if (EnemyHealth <= 10)
            {
                enemySpawner.StopSpawner();
            }

            if (EnemyHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }


    void Update()

    {

        Camera camera = Camera.main;
        float screen_height = camera.orthographicSize;
        float screen_width = screen_height * camera.aspect;
        startPosition = new Vector3(screen_width - VisualWidth / 2, 0, 0);

        if (Move) //bool is checked
                  //See if you can work out whats going on here, for your own enjoyment
            bounceObject.transform.position = startPosition + MoveVector * (MoveRange * Mathf.Sin(Time.timeSinceLevelLoad * MoveSpeed));



        if (myStatusBoss == BossEnemyStatus.Alive)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {

                Vector3 bossPosition = new Vector3(screen_width, Random.Range(-screen_height, screen_height), 0);
                Instantiate(
                     bullet_boss_Prefab,
                     transform.position + new Vector3(-VisualWidth,0),
                     transform.rotation);

                timer = 2;
                Debug.Log("boss fire");

            }
        }
    }
}
        
