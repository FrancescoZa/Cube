using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneScript : enemyBehavior
{

    public GameObject player;
    public GameObject camera;
    private AudioSource audioSource;

    private Transform playerPos;
    private Vector2 currentPos;
    public float distance;
    public float speedEnemy = 1f;
    Rigidbody2D rb;
    bool follow = true;
    bool returnToY = false;
    bool returnToX = false;
    float Y;
    float X;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
        rb = GetComponent<Rigidbody2D>();
        Y = currentPos.y;
        X = currentPos.x;

        setSoundEffect(audioSource);

    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            if (Vector3.Distance(transform.position, playerPos.position) < distance)
            {

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerPos.position.x + 0.2f, transform.position.y, playerPos.position.z), speedEnemy * Time.deltaTime);



            }
            else
            {
                if (Vector3.Distance(transform.position, currentPos) > 0)
                {
                    //goes to the default position
                    transform.position = Vector3.MoveTowards(transform.position, currentPos, speedEnemy * Time.deltaTime);
                }

            }
        }


        if (transform.position.x >= playerPos.position.x-0.5 && transform.position.x <= playerPos.position.x + 0.5)//stone has reached the player
		{
            rb.gravityScale = 2;
            follow = false;
		}

        

    }

	private void FixedUpdate()
	{
		if (returnToY)
		{
            rb.gravityScale = 0; //i put it here because i had problem inside onCollisionCollider. it was hitting the player several times before putting gravity to 0

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Y, playerPos.position.z), speedEnemy * Time.deltaTime);

        }

        if (returnToX)
        {

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(X, transform.position.y, playerPos.position.z), speedEnemy * Time.deltaTime);

        }

        if (transform.position.y == Y && returnToX == false)
		{
            returnToY = false;
            follow = true;

        }

        if (transform.position.x == X) 
        {
            returnToX = false;
            follow = true;

        }

        if (transform.position.x <= currentPos.x - 15f || transform.position.x >= currentPos.x + 15f)   //if the stone goes over its space then it returns to its default position
        {
            follow = false;
            returnToX = true;
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        audioSource.Play();

        camera.GetComponent<cameraShake>().shake();


        if (collision.transform.tag == "Player")
        {
            player.GetComponent<PlayerController>().Hit();

        }

        returnToY = true;
       
    }

}
