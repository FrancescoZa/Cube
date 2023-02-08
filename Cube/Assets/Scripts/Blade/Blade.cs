using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float rotateSpeed;


    private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.tag == "Player")
        player.GetComponent<PlayerController>().Hit();
    }

  

	// Update is called once per frame
	void Update()
    {
        //transform.Rotate(0,0,rotateSpeed);
        transform.Rotate(new Vector3(0, 0, rotateSpeed*(-1)) * Time.fixedDeltaTime);


    }
}
