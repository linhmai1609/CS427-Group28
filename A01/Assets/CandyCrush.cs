using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCrush : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject candy_0;
    public GameObject candy_1;
    public GameObject candy_2;
    public GameObject candy_3;
    public GameObject candy_4;
    public int height = 10;
    public int width = 10;
    void Start()
    {

        for(int i = 0; i <= width; i+=2)
        {
            for(int j = 0; j<= height; j+=2) { 
            System.Random rnd = new System.Random();
            int var = rnd.Next(5);
            if (var == 0)
            {
                Instantiate(candy_0, new Vector3(i, j, 0), Quaternion.identity);
            }
            else if (var == 1)
            {
                Instantiate(candy_1, new Vector3(i, j, 0), Quaternion.identity);
            }
            else if (var == 2)
            {
                Instantiate(candy_2, new Vector3(i, j, 0), Quaternion.identity);
            }
            else if (var == 3)
            {
                Instantiate(candy_3, new Vector3(i, j, 0), Quaternion.identity);
            }
            else if (var == 4)
            {
                Instantiate(candy_4, new Vector3(i, j, 0), Quaternion.identity);
            }
           
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
