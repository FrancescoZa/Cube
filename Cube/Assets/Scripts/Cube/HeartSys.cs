using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSys : MonoBehaviour
{

    public GameObject[] hearts;
    public int life;
    public GameObject player;

    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;


        if (!PlayerPrefs.HasKey("numeroVite")) //se non ho mai salvato lo setto al 100%
        {
            PlayerPrefs.SetInt("numeroVite", 3);
        }

        int vite = PlayerPrefs.GetInt("numeroVite");

		for (int i = 0; i< life - vite; i++)
		{
            takeDamage();
		}

    }

    public void takeDamage()
	{
        try
        {
            life = life - 1;
            Destroy(hearts[life].gameObject);

            if (life < 1)
            {
                dead = true;
            }
		}
		catch 
		{

		}

	}

    // Update is called once per frame
    void Update()
    {
        if(dead == true)
		{
            //die method
            player.GetComponent<PlayerController>().Died();

        }
    }
}
