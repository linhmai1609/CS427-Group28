using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateScene : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject Prefab1, Prefab2, Prefab3, Prefab4, Prefab5;
    public GameObject[,] candyList = new GameObject[5, 5];

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        System.Random rnd = new System.Random();
        for (int i=0; i< 5; ++i)
        {
            for (int j=0; j<5; ++j)
            {
                switch(rnd.Next(1,4))
                {
                    case 1:
                        candyList[i,j] = Instantiate(Prefab1, new Vector3(i+1/2, j+1/2, 0), Quaternion.identity);
                        break;
                    case 2:
                        candyList[i, j] = Instantiate(Prefab2, new Vector3(i + 1 / 2, j + 1 / 2, 0), Quaternion.identity);
                        break;
                    case 3:
                        candyList[i, j] = Instantiate(Prefab3, new Vector3(i + 1 / 2, j + 1 / 2, 0), Quaternion.identity);
                        break;
                    case 4:
                        candyList[i, j] = Instantiate(Prefab4, new Vector3(i + 1 / 2, j + 1 / 2, 0), Quaternion.identity);
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
