using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatformScript : MonoBehaviour
{
    bool move = true;
    public float speed = 30.5f;
    [SerializeField] GameObject marginLeft;
    [SerializeField] GameObject marginRight;
    [SerializeField] GameObject player;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

    }

    private void FixedUpdate()
	{
		if(transform.position.x >= marginRight.transform.position.x)
		{
            move = false;
            speed = speed * (-1);
            move = true;
		}else if (transform.position.x <= marginLeft.transform.position.x)
		{
            move = false;
            speed = speed * (-1);
            move = true;

		}
		
    }
}
