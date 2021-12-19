using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public void CreateNewDotRotation()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + Random.Range(180.0f, 300.0f));
        transform.rotation = rotation;
    }
}
