using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTouch : MonoBehaviour
{
	// Start is called before the first frame update

	public GameObject levelChanger;

	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.transform.tag == "Enemy")
		{
			
			var collisionPoint = other.ClosestPoint(transform.position);
			Vector2 collisionNormal = (Vector2)transform.position - collisionPoint;
			//print(collisionNormal.y);
			if (collisionNormal.y >= 0.48)
			{
				//Destroy(this);
				other.GetComponent<Collider2D>().enabled = false;
				GetComponent<PlayerController>().jump();
				other.GetComponent<Enemy>().die();
			}
			else
			{
				GetComponent<PlayerController>().Hit();
				GetComponent<PlayerController>().jump();
			}


		}


		if (other.transform.tag == "Talpa")
		{



			var collisionPoint = other.ClosestPoint(transform.position);
			Vector2 collisionNormal = (Vector2)transform.position - collisionPoint;

			if (collisionNormal.y >= 0.45)
			{
				//Destroy(this);
				other.GetComponent<Collider2D>().enabled = false;
				GetComponent<PlayerController>().jump();
				other.GetComponent<Talpa>().die();
			}
			else
			{
				GetComponent<PlayerController>().Hit();
				GetComponent<PlayerController>().jump();
			}


		}

		if (other.transform.tag == "Bird")
		{
			GetComponent<PlayerController>().Hit();
			
		}

		if(other.transform.tag == "flyEnem")
		{
			GetComponent<PlayerController>().Hit();

		}

		if (other.transform.tag == "Portal")
		{
			PlayerPrefs.SetInt("savedLevel", SceneManager.GetActiveScene().buildIndex + 1);
			Checkpoint.resetCheckpoint();

			levelChanger.GetComponent<LevelChanger>().FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1); //se devo cambiare livello, devo mettere l'ogetto levelChanger anche nella nuova scena

		}


	}

}
