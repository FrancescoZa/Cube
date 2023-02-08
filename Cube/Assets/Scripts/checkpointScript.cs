using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointScript : MonoBehaviour
{

    private AudioSource audioSource;
	public PlayerController player;


	// Start is called before the first frame update
	void Start()
    {

		audioSource = GetComponent<AudioSource>();


		if (!PlayerPrefs.HasKey("soundsEffect")) //se non ho mai salvato lo setto al 100%
		{
			PlayerPrefs.SetFloat("soundsEffect", 1);
		}

		audioSource.volume = 1;// PlayerPrefs.GetInt("soundsEffect");


	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.transform.tag == "Player")
		{
			player.checkpoint = true;
			Checkpoint.updateCheckpoint(collision.transform.position.x, collision.transform.position.y);
			GetComponent<AudioSource>().Play();


		}
	}


}
