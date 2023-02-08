using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivator : MonoBehaviour
{

    bool activated = false;
    [SerializeField] GameObject trapObject;
    public float height;

    // Start is called before the first frame update

    float finalDest;

    void Start()
    {
        finalDest = trapObject.transform.position.y + height;
    }



    // Update is called once per frame
    void Update()
    {
		if (activated)
		{
            trapObject.transform.position = Vector3.MoveTowards(trapObject.transform.position, new Vector3(trapObject.transform.position.x, trapObject.transform.position.y + height, trapObject.transform.position.z), 1 * Time.deltaTime);
            
        }

        if(trapObject.transform.position.y >= finalDest)
		{
            activated = false;
		}

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.transform.tag == "TrapSensor")
		{
            activated = true;
		}

        if (collision.transform.tag == "Trap")
        {
            gameObject.GetComponent<PlayerController>().Hit();
            gameObject.GetComponent<PlayerController>().jump();

        }

    }

}
