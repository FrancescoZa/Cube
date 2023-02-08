using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdActivator : MonoBehaviour
{

    [SerializeField] GameObject Bird;
    bool spawn = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{

        if (!spawn)
        {
            //Instantiate(Bird, new Vector3(69.26f, -0.79f, 0f), Quaternion.identity);
            Instantiate(Bird, new Vector3(collision.transform.position.x + 10, collision.transform.position.y + 0.2f, 0f), Quaternion.identity);

            spawn = true;
        }
    }

	
}
