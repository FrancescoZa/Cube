using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey("soundsEffect")) //se non ho mai salvato lo setto al 100%
        {
            PlayerPrefs.SetFloat("soundsEffect", 1);
        }

        audioSource.volume = PlayerPrefs.GetInt("soundsEffect");
    }

	
}
