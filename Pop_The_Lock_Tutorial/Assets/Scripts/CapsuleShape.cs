using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleShape : MonoBehaviour
{
    public Transform ring, dot;

    [SerializeField]
    private bool isLeftOrRight; // true is right, false is left...

    public float rotationSpeed;

    void OnEnable()
    {
        if(dot.rotation.eulerAngles.z <= 180.0f) 
            isLeftOrRight = false;
        else 
            isLeftOrRight = true;

        print("dot.rotation.eulerAngles.z: " + dot.rotation.eulerAngles.z);
        print("dot.rotation.z: " + dot.rotation.z);
    }

    void Update()
    {
        if(isLeftOrRight)
        {
            transform.RotateAround(ring.position, Vector3.back, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(ring.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    public void ChangeRotateDirection()
    {
        if(isLeftOrRight) 
            isLeftOrRight = false;
        else 
            isLeftOrRight = true;
    }
}
