using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public GameObject bullet_enemy_Prefab;

    public float timer = 0.5f;

    public EnemyStatus myStatus = EnemyStatus.Alive;


    public enum EnemyStatus
    {
        Alive,
        Explonding,
        Dead
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (myStatus == EnemyStatus.Alive)
        {
            if (other.tag == "bullet_prefab")
            {
                gameObject.SetActive(false);
                other.gameObject.SetActive(false);
                PlayerControl.Player.AddEnemyKilled();               
                myStatus = EnemyStatus.Dead;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (myStatus == EnemyStatus.Alive)
        {
            transform.position = transform.position + new Vector3(-5, 0, 0) * Time.deltaTime;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                var bullet = (GameObject)Instantiate(
                bullet_enemy_Prefab,
                transform.position,
                transform.rotation);


                // Destroy the bullet after 2 seconds
                Destroy(bullet, 2.0f);
                timer = 0.5f;
            }
        }

        
    }
}
