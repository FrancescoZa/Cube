using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakGround : MonoBehaviour
{
    int strength = 3;
    
    SpriteRenderer groundRender;
    [SerializeField] GameObject[] cracksArr;
    [SerializeField] GameObject cracks;
    // Start is called before the first frame update
    void Start()
    {
        
        cracksArr = new GameObject[3];

        groundRender = gameObject.GetComponent<SpriteRenderer>();
        
    }

   
    

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.transform.tag == "Stone")
		{
            strength = strength - 1;
            
            if(strength == 2)
			{
                cracksArr[0] = Instantiate(cracks, new Vector3(103.9f, -0.7f, -0.43f), Quaternion.identity);

            }
            if(strength == 1)
			{
                cracksArr[1] = Instantiate(cracks, new Vector3(105.49f, -0.48f, -0.43f), Quaternion.Euler(0, 180f, 0));
                cracksArr[2] = Instantiate(cracks, new Vector3(102.4f, -0.48f, -0.43f), Quaternion.Euler(0, 180f, 0));

            }

            if (strength == 0)
			{
                Destroy(gameObject);
                Destroy(cracksArr[0]);
                Destroy(cracksArr[1]);
                Destroy(cracksArr[2]);

            }
        }
	}

}
