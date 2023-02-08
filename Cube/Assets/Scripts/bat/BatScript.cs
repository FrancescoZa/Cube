using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : enemyBehavior
{


    public int lives = 3;
    public float speedEnemy = 1f;
    public GameObject player;
    private Transform playerPos;
    private Vector2 currentPos;

    public GameObject healthBar;

    private bool faceDirection = true;      //true = left             false = right
    private bool newFaceDirection = true;
    public float distance;

    public Animator dieAnimation;

    public ParticleSystem hitParticles;

    public float fireRate = 1f;
    float nextFire;
    public GameObject bullet;

    public AudioSource audioSource;
    public AudioClip hitSound;
    float decrementFactor;
    bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();


        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;

        healthBar = transform.GetChild(0).gameObject;

        decrementFactor = (healthBar.gameObject.transform.localScale.x)/lives;  //length of healthBar

        nextFire = Time.time;

        setSoundEffect(audioSource);

    }

    
    void checkTimetoFire()
	{
        if(!dead)
        if(Time.time > nextFire)
		{

			if (playerPos.position.x < transform.position.x -2)
				Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, -144));
			else if (playerPos.position.x > transform.position.x + 2)
				Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, -21));
			else
				Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, -80));

			nextFire = Time.time + fireRate;
        }
	}
    

    private void OnTriggerEnter2D(Collider2D collision)
	{
        //print(collision.transform.tag);
        if (collision.transform.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            lives--;

            healthBar.gameObject.transform.localScale -= new Vector3(decrementFactor, 0, 0);
            hitParticles.Play();
            audioSource.PlayOneShot(hitSound);

            if (lives == 0)
            {
                audioSource.Play();
                dead = true;
                Vector3 Scaler = transform.localScale;
                Scaler.y = Scaler.y * -1;   //flip vertically
                transform.localScale = Scaler;
                GetComponent<Collider2D>().enabled = false;
                dieAnimation.SetTrigger("die");

            }
        }
    }

	public void batDestroy()
	{
        Destroy(transform.parent.gameObject);  //it deletes the parent (and bat gameobject)
    }

	

    // Update is called once per frame
    void Update()
    {
       

            if (Vector3.Distance(transform.position, playerPos.position) < distance)
            {

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerPos.position.x + 0.2f, playerPos.position.y + 4f, playerPos.position.z), speedEnemy * Time.deltaTime);

                if (playerPos.position.x < transform.position.x)
                {
                    newFaceDirection = true;    //left
                    if (newFaceDirection != faceDirection) flip();
                    faceDirection = newFaceDirection;
                }
                else
                {
                    newFaceDirection = false;    //right
                    if (newFaceDirection != faceDirection) flip();
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

            if (transform.position.x == playerPos.position.x)    //the bat has reached the player
            {

            transform.position = Vector3.MoveTowards(transform.position, currentPos, speedEnemy * Time.deltaTime);

            }


    }

   

}
