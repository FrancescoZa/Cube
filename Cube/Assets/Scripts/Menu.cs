using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Menu : MonoBehaviour
{
	public GameObject levelChanger;


	private void Start()
	{
		Checkpoint.resetCheckpoint();

	}


	public void playGame()
	{


		if (!PlayerPrefs.HasKey("savedLevel")) //se non ho mai salvato lo setto al 100%
		{
			PlayerPrefs.SetInt("savedLevel", 2);
		}
		print(PlayerPrefs.GetInt("savedLevel"));
		SceneManager.LoadScene(PlayerPrefs.GetInt("savedLevel"));
	}



	public static void settings()
	{
		SceneManager.LoadScene(1);

	}

	public static void playQuit()
	{
		Application.Quit();

	}

}


