using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroScript01 : MonoBehaviour
{
    public Vector2 newPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = newPosition;
        Debug.Log(newPosition);
    }
}
