using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Checkpoint
{

	public static float posX;
	public static float posY;

	public static void resetCheckpoint()
	{
		posX = -24.1f;
		posY = 0.81f;

		
		PlayerPrefs.SetFloat("playerPosX", -24.1f);
	

	
		PlayerPrefs.SetFloat("playerPosY", 0.81f);
		

	}

	public static void updateCheckpoint(float posX, float posY)
	{

		PlayerPrefs.SetFloat("playerPosX", posX);
		PlayerPrefs.SetFloat("playerPosY", posY);

		

	}
   
}
