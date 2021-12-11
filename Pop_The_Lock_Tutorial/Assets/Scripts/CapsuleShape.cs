using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleShape : MonoBehaviour
{
    public Transform ring;

    [SerializeField]
    private bool isLeftOrRight; // true is right, false is left...

    private float rotationSpeed;

    void Start()
    {
        isLeftOrRight = true;
        rotationSpeed = 50.0f;
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
        if(isLeftOrRight) isLeftOrRight = false;
        else isLeftOrRight = true;
    }
}
