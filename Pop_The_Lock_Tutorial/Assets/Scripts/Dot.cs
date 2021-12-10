using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{

    void Start()
    {
        CreateNewDotRotation();
    }

    void Update()
    {
        
    }

    public void CreateNewDotRotation()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360.0f));
        transform.rotation = rotation;
    }
}
