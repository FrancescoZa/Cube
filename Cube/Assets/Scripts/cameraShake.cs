using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
	// Start is called before the first frame update
	public float duration = 2f;
	public float magnitude = 10f;
	[SerializeField] GameObject player;
    public void shake()
	{
		StartCoroutine(shakeNum());
		
	}


    public IEnumerator shakeNum()
	{

		Vector3 originalPosition = GetComponent<Transform>().localPosition;
		float time = 0f;

		while(time < duration)
		{
			float xVar = Random.Range(-0.4f, +0.5f) * magnitude;
			float yVar = Random.Range(-0.4f, +0.5f) * magnitude;

			transform.localPosition = new Vector3(player.transform.position.x + xVar, transform.localPosition.y + yVar, originalPosition.z);
			time = time + Time.deltaTime;
			yield return 0; //wait for 1 frame.
		}

		

	}

}
