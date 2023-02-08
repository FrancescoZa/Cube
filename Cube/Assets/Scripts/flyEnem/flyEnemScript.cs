using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyEnemScript : enemyBehavior
{

    public float speedEnemy = 1f;
    public GameObject player;
    private Transform playerPos;
    private Vector2 currentPos;
    private bool faceDirection = true;      //true = left             false = right
    private bool newFaceDirection = true;
    public float distance;
    public ParticleSystem hitParticles;
    public Animator dieAnimation;
    bool dead = false;
    float nextFire;
    public GameObject bullet;
    public float fireRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
        nextFire = Time.time;

    }


    void checkTimetoFire()
    {
        if (!dead)
            if (Time.time > nextFire)
            {

                if (playerPos.position.x < transform.position.x - 2)
                    Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, -144));
                else if (playerPos.position.x > transform.position.x + 2)
                    Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, -21));
                else
                    Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, -80));

                nextFire = Time.time + fireRate;
            }
    }

    public void onDieEnemy()
	{
        Destroy(transform.parent.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            dead = true;
            hitParticles.Play();
            dieAnimation.SetTrigger("Die");
            Destroy(collision.gameObject);

        }
    }

        // Update is called once per frame
        void Update()
    {

        if (Vector3.Distance(transform.position, playerPos.position) < distance)
        {

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerPos.position.x + 0.2f, playerPos.position.y + 3.5f, playerPos.position.z), speedEnemy * Time.deltaTime);

            if (playerPos.position.x < transform.position.x)
            {
                newFaceDirection = true;    //left
                if (newFaceDirection != faceDirection) {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);

                }
                faceDirection = newFaceDirection;
            }
            else
            {
                newFaceDirection = false;    //right
                if (newFaceDirection != faceDirection)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);

                }
                faceDirection = newFaceDirection;

            }

            checkTimetoFire();

        }
        else
        {
            if (Vector3.Distance(transform.position, currentPos) > 0)
            {
                //goes to the default position
                transform.position = Vector3.MoveTowards(transform.position, currentPos, speedEnemy * Time.deltaTime);
            }

        }

        if (transform.position.x == playerPos.position.x)    //the flyMonster has reached the player
        {

            transform.position = Vector3.MoveTowards(transform.position, currentPos, speedEnemy * Time.deltaTime);

        }

    }
}
