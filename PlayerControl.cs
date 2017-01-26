using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed = 5;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

    public int EnemiesKilled = 0;

    public static PlayerControl Player;

    private Rigidbody2D m_Rigidbody;


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        Player = this;
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            float health = GetComponent<PlayerHealth>().TakeDamage(10f);
            other.gameObject.SetActive(false);

            }
        if (other.tag == "bullet_enemy")
        {
            float health = GetComponent<PlayerHealth>().TakeDamage(10f);
            other.gameObject.SetActive(false);

        }
    }
    
    




public void AddEnemyKilled()
{
    EnemiesKilled++;
    Debug.Log(EnemiesKilled);

    if (EnemiesKilled == 1)
    {
        EnemySpawner.Instance.CreateBoss();
    }
}


    // Use this for initialization
    void Start ()
	{
       
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKeyDown (KeyCode.Space)) {
			Fire ();
		}
	}
	

		void Fire()
		{
			// Create the Bullet from the Bullet Prefab
			var bullet = (GameObject)Instantiate (
				bulletPrefab,
				bulletSpawn.position,
				bulletSpawn.rotation);

	
			// Destroy the bullet after 2 seconds
			Destroy(bullet, 2.0f);
		}

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;
        m_Rigidbody.MovePosition(m_Rigidbody.position + new Vector2(x * Time.deltaTime, y * Time.deltaTime));

    }




}

