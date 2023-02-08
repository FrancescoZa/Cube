using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMove : MonoBehaviour
{

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    
    public float speed = 2.5f;

    public LayerMask groundLayer;
    private bool mustTurn;


    void patrol()
    {

        if (mustTurn)
        {
            speed = speed * (-1);
        }

       // transform.position = transform.position + new Vector3(speed*Time.fixedDeltaTime, transform.position.y, 0);
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

    }

    private void FixedUpdate()
    {

        if (speed > 0)
            mustTurn = !Physics2D.OverlapCircle(groundCheckRight.position, 0.1f, groundLayer);
        else
            mustTurn = !Physics2D.OverlapCircle(groundCheckLeft.position, 0.1f, groundLayer);


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        patrol();

    }
}
