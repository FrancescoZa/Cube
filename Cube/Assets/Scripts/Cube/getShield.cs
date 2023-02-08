using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getShield : MonoBehaviour
{

	[SerializeField] GameObject light;

	SpriteRenderer lightRender;
	public PlayerController script;

	// Start is called before the first frame update

	private void Start()
	{
		lightRender = light.GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.transform.tag == "Potion")
		{
			script.shield = true;
			lightRender.color = new Color(0, 247, 255, 0.83f);
			Destroy(collision.gameObject);
		}

		if (collision.transform.tag == "potionJump")
		{
			lightRender.color = new Color(251, 244, 0, 0.4f);
			Destroy(collision.gameObject);
			script.jumpForce = 13;
			script.extraJumpsValue = 0;
			GetComponent<PlayerController>().jump();
		}

		

	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.transform.name == "disableJump")
		{
			lightRender.color = new Color(255, 255, 255, 0.4f);

			script.jumpForce = 5;
			script.extraJumpsValue = 1;
		}
	}

	public void shieldDestroyed()
	{
		lightRender.color = new Color(255, 255, 255, 0.83f);
	}
}
