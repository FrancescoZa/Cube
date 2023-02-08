using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteManager : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {

        //background2
        Instantiate(Background2, new Vector3(14.96716f, 16.0112f, 0.1f), Quaternion.identity);
        Instantiate(Background2, new Vector3(64.1f, 16.0112f, 0.1f), Quaternion.identity);
        Instantiate(Background2, new Vector3(100.1f, 16.0112f, 0.1f), Quaternion.identity);
        Instantiate(Background2, new Vector3(136.1f, 16.0112f, 0.1f), Quaternion.identity);
        Instantiate(Background2, new Vector3(172.2f, 16.0112f, 0.1f), Quaternion.identity);
        Instantiate(Background2, new Vector3(208.5f, 16.0112f, 0.1f), Quaternion.identity);
        Instantiate(Background2, new Vector3(201.8f, 30, 0.1f), Quaternion.identity);
        Instantiate(Background2, new Vector3(165.7f, 30, 0.1f), Quaternion.identity);
        Instantiate(Background2, new Vector3(201.8f, 43.7f, 0.1f), Quaternion.identity);
        Instantiate(Background2, new Vector3(165.7f, 43.7f, 0.1f), Quaternion.identity);


        //enemies
        Instantiate(Enemy, new Vector3(-11, -2.05f, -0.12f), Quaternion.identity);
        Instantiate(Enemy, new Vector3(25.73f, -2.64f, -0.12f), Quaternion.identity);
        Instantiate(Enemy, new Vector3(95.47f, 0.55f, -0.12f), Quaternion.identity);
        Instantiate(Enemy, new Vector3(95.47f + 10f, 0.55f, -0.12f), Quaternion.identity);

        //enemy4
        Instantiate(enemy4, new Vector3(142.88f, -0.31f, 0), Quaternion.identity);
        Instantiate(enemy4, new Vector3(154.6f, -0.31f, 0), Quaternion.identity);
        

        //coins
        Instantiate(Coins, new Vector3(2.16f, -0.2f, 0), Quaternion.identity);
        Instantiate(Coins, new Vector3(4.36f, -0.2f, 0), Quaternion.identity);
        Instantiate(Coins, new Vector3(11.53f, 1.79f, 0), Quaternion.identity);
        Instantiate(Coins, new Vector3(13.68f, 1.79f, 0), Quaternion.identity);
        Instantiate(Coins, new Vector3(20.12f, -0.36f, 0), Quaternion.identity);
        Instantiate(Coins, new Vector3(25, -2.33f, 0), Quaternion.identity);
        Instantiate(Coins, new Vector3(27.39f, -2.33f, 0), Quaternion.identity);
        Instantiate(Coins, new Vector3(42.3f, -2.33f, 0), Quaternion.identity);
        Instantiate(Coins, new Vector3(45, -2.33f, 0), Quaternion.identity);

        Instantiate(Coins, new Vector3(62.46f, -2.01f, 0), Quaternion.identity);

        Instantiate(Coins, new Vector3(144.74f, -0.13f, 0), Quaternion.identity);
        Instantiate(Coins, new Vector3(148.65f, -0.13f, 0), Quaternion.identity);
        Instantiate(Coins, new Vector3(152.66f, -0.13f, 0), Quaternion.identity);
        Instantiate(Coins, new Vector3(186.74f, 26.63f, 0), Quaternion.identity);
        Instantiate(Coins, new Vector3(184.5f, 22.46f, 0), Quaternion.identity);
        Instantiate(Coins, new Vector3(188.94f, 22.46f, 0), Quaternion.identity);


        float posX = 90f;
        for(int i = 0; i<=6; i++)
		{
            Instantiate(Coins, new Vector3(posX, 1.05f, 0), Quaternion.identity);
            posX = posX + 5;
        }

        posX = 107.5f;
        for (int i = 0; i<3; i++)
		{
            Instantiate(Coins, new Vector3(posX, -2.52f, 0), Quaternion.identity);
            posX = posX + 5;
        }


        posX = 168f;
        for (int i = 0; i < 5; i++)
        {
            Instantiate(Coins, new Vector3(posX, 11.17f, 0), Quaternion.identity);
            posX = posX + 5;
        }

        //20Coins
        Instantiate(Coins20, new Vector3(13.63f, 10f, 0), Quaternion.identity);
        Instantiate(Coins20, new Vector3(152.23f, 0.04f, 0), Quaternion.identity);


        //eye
        Instantiate(Eye, new Vector3(2.64f, 0.81f, 0), Quaternion.identity);
        Instantiate(Eye, new Vector3(7.86f, 0.28f, 0), Quaternion.identity);
        Instantiate(Eye, new Vector3(4.1f, 5.35f, 0), Quaternion.identity);


        //plants
        Instantiate(Plant, new Vector3(3.48f, -0.96f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(10.18f, -0.96f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(17.39f, -0.96f, 0), Quaternion.identity);

        Instantiate(Plant, new Vector3(-9.78f, -2.37f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(-3.81f, -2.37f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(-23.82f, -2.37f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(-17.95f, -2.37f, 0), Quaternion.identity);



        Instantiate(Plant, new Vector3(25.76f, -2.95f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(31.57f, -2.95f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(38.45f, -2.95f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(44.14f, -2.95f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(72.78f, 0.45f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(91.34f, 0.45f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(97.76f, 0.45f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(109.91f, 0.45f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(116.9f, 0.45f, 0), Quaternion.identity);

        Instantiate(Plant, new Vector3(139.384f, -0.42f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(148.85f, -0.42f, 0), Quaternion.identity);
        Instantiate(Plant, new Vector3(159, -0.42f, 0), Quaternion.identity);


        //background
        posX = 7;

        Instantiate(Background, new Vector3(-35f, 2.08f, 1), Quaternion.Euler(0, 180f, 0));


        for (int i = 0; i<=5; i++)
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

        //plantBlur
        posX = -7.68f;
        float posY = -5.91f;


        Instantiate(PlantBlur, new Vector3(-33.33f, -5.88f, -0.66f), Quaternion.Euler(0, 180f, 0));

        Instantiate(PlantBlur, new Vector3(-20.49f, -5.88f, -0.66f), Quaternion.identity);


        for (int i = 1; i <= 8; i++)
		{

            

            if (i%2 == 0)
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

        posX = 92.94f;
        for (int i = 0; i <=4; i++) {
            if (i % 2 == 0)
            {
                Instantiate(PlantBlur, new Vector3(posX, -6.42f, -0.66f), Quaternion.Euler(0, 180f, 0));
			}
			else
			{
                Instantiate(PlantBlur, new Vector3(posX, -6.42f, -0.66f), Quaternion.identity);
            }
            posX = posX + 12.84f;
        }


        //soil
        Instantiate(Soil, new Vector3(104.06f, -2.26f, 0.07f), Quaternion.identity);
        Instantiate(Soil, new Vector3(110.8f, -2.26f, 0.07f), Quaternion.Euler(0, 180f, 0));
        Instantiate(Soil, new Vector3(117.43f, -2.26f, 0.07f), Quaternion.identity);
        Instantiate(Column, new Vector3(120.79f, -2.352f, 0.04f), Quaternion.identity);


    }




}
