using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

	private void FixedUpdate()
	{

		if(player.position.y > -3.0f)
		transform.position = new Vector3(player.position.x, player.position.y+2, transform.position.z);
		
	}

}
