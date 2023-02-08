using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
	

	public AudioSource audioSource;


	void Start()
	{


		if (!PlayerPrefs.HasKey("musicVolume")) //se non ho mai salvato lo setto al 100%
		{
			PlayerPrefs.SetFloat("musicVolume", 0);
		}
		audioSource.volume = PlayerPrefs.GetFloat("musicVolume");

	}

	
}
