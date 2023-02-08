using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : enemyBehavior
{

    [HideInInspector]
    private float walkSpeed = 3f;

    public bool mustMove;
    private bool mustTurn;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator dieAnimation;

    public ParticleSystem dieParticles;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {



        mustMove = true;

        setSoundEffect(audioSource);

    }

    // Update is called once per frame
    void Update()
    {
		if (mustMove)
		{
            move();
		}
    }

	private void FixedUpdate()
	{

		if (mustMove)
		{
            
                mustTurn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
				//if there is not ground, FALSE
				//mustTurn = TRUE
			
		}

	}

	void move()
	{

		if (mustTurn)
		{
            flip();
		}

        transform.position += new Vector3(walkSpeed * Time.deltaTime, 0, 0);

    }

   

    public override void flip()
	{
        mustMove = false;
		transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
		walkSpeed = walkSpeed * -1;
		mustMove = true;
	}

   


    public void die()
	{

        destroy(dieParticles, dieAnimation);
	}

}
