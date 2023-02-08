using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{


    public void onCreditsComplete()
	{

        PlayerPrefs.SetInt("savedLevel", 2);
        SceneManager.LoadScene(0);


    }

    // Update is called once per frame

}
