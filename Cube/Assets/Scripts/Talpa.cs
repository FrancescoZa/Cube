using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talpa : enemyBehavior
{
    public ParticleSystem dieParticles;
    public Animator dieAnim;
	private AudioSource audioSource;


	// Start is called before the first frame update
	private void Start()
	{
        setSoundEffect(audioSource);
    }

	public void die()
    {
        destroy(dieParticles, dieAnim);

    }

}
