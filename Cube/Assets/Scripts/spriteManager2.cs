using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteManager2 : MonoBehaviour
{

    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Coins;
    [SerializeField] GameObject Coins20;
    [SerializeField] GameObject Eye;
    [SerializeField] GameObject Plant;
    [SerializeField] GameObject PlantBlur;
    [SerializeField] GameObject Background;
    [SerializeField] GameObject Background2;
    [SerializeField] GameObject Soil;
    [SerializeField] GameObject Column;
    [SerializeField] GameObject enemy4;

    void Start()
    {

        //background
        float posX = 7;

        Instantiate(Background, new Vector3(-35f, 2.08f, 1), Quaternion.Euler(0, 180f, 0));


        for (int i = 0; i <= 5; i++)
        {
            if (i % 2 == 0)
            {
                Instantiate(Background, new Vector3(posX, 2.08f, 1), Quaternion.identity);
            }
            else
            {
                Instantiate(Background, new Vector3(posX, 2.08f, 1), Quaternion.Euler(0, 180f, 0));

            }

            posX = posX + 42f;
        }

        Instantiate(Background2, new Vector3(18.73f, 16f, 0.1f), Quaternion.identity);
        Instantiate(Background2, new Vector3(55.08f, 16f, 0.1f), Quaternion.identity);
        Instantiate(Background2, new Vector3(91.3f, 16f, 0.1f), Quaternion.identity);

        //enemies
        Instantiate(Enemy, new Vector3(-8.9f, -2f, -0.12f), Quaternion.identity);
        Instantiate(Enemy, new Vector3(13.38f, -2.95f, -0.12f), Quaternion.identity);
        Instantiate(enemy4, new Vector3(4.56f, -2.05f, 0), Quaternion.identity);

        //coins

        Instantiate(Coins20, new Vector3(45.64f, 5.67f, 0), Quaternion.identity);


        Instantiate(Coins, new Vector3(-5.84f, -1.82f, 0), Quaternion.identity);
        Instantiate(Coins, new Vector3(10.67f, -1.82f, 0), Quaternion.identity);

        float x = 13.11f;
        for(int i = 0; i<4; i++)
		{
            Instantiate(Coins, new Vector3(x, -0.14f, 0), Quaternion.identity);
            x = x + 3;
        }

        float y = 13.33f;
        for(int i = 0; i<7; i++)
		{
            Instantiate(Coins, new Vector3(69.21f, y, 0), Quaternion.identity);
            y = y - 2;
        }

        Instantiate(Coins, new Vector3(88.32f, 0.71f, 0), Quaternion.identity);

        Instantiate(Coins, new Vector3(90.04f, 0.71f, 0), Quaternion.identity);

        //plants
        Instantiate(Plant, new Vector3(-8.8f, -2.21f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(-2.69f, -2.21f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(14.9f, -3.12f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(26.17f, -0.84f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(32.61f, -0.84f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(42.91f, 5.01f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(48.94f, 5.01f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(74f, 0.6f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(85f, 0.18f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(93.74f, 0.18f, 0), Quaternion.identity);

        Instantiate(PlantBlur, new Vector3(-33.33f, -5.88f, -0.66f), Quaternion.Euler(0, 180f, 0));

        Instantiate(PlantBlur, new Vector3(-20.49f, -5.88f, -0.66f), Quaternion.identity);



        //plantBlur
        posX = -7.68f;
        float posY = -5.91f;

        for (int i = 1; i <= 8; i++)
        {



            if (i % 2 == 0)
            {
                Instantiate(PlantBlur, new Vector3(posX, posY, -0.66f), Quaternion.identity);
            }
            else
            {
                Instantiate(PlantBlur, new Vector3(posX, posY, -0.66f), Quaternion.Euler(0, 180f, 0));

            }

            posX = posX + 12.84f;

            if (i > 1) posY = -6.55f;


        }


    }


}
