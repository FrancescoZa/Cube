using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairsMovement : MonoBehaviour
{

    private float vertical;
    private float speed = 8f;
    private bool touch;
    private bool isClimbing;

    [SerializeField] Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if(touch && Mathf.Abs(vertical) > 0f)   //absolute function. it makes positive a negative number
		{
            isClimbing = true;
		}

    }


	private void FixedUpdate()
	{
        if (isClimbing) {

            rb.gravityScale = 16f;   //set the gravity of player to 0
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);

		}
		else
		{
            rb.gravityScale = 1f;   //if it is not climbing, i set the gravity back to 1
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.transform.tag == "Stairs")
		{
            touch = true;

        }
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.transform.tag == "Stairs")
        {
            touch = false;
            isClimbing = false;
        }
    }

}
