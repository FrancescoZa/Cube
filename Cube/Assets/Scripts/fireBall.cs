using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    // Start is called before the first frame update

    float moveSpeed = 7f;
    GameObject player;

    Rigidbody2D rb;
    Vector2 moveDirection;


    void Start()
    {
        player = GameObject.FindWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(player.transform.forward * moveSpeed);
        moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

	// Update is called once per frame

	private void OnTriggerEnter2D(Collider2D other)
	{

        if(other.transform.tag == "Player")
		{
            player.GetComponent<PlayerController>().Hit();

            Destroy(gameObject);

        }else if (other.transform.tag == "Ground")
		{
            Destroy(gameObject);

        }


    }
}
