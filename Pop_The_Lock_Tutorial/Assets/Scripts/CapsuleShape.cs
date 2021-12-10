using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleShape : MonoBehaviour
{
    public Transform ring;

    [SerializeField]
    private bool isLeftOrRight; // true is right, false is left...

    void Start()
    {
        isLeftOrRight = true;
    }

    void Update()
    {
        if(isLeftOrRight)
        {
            transform.RotateAround(ring.position, Vector3.back, 20.0f * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(ring.position, Vector3.forward, 20.0f * Time.deltaTime);
        }
    }

    public void ChangeRotateDirection()
    {
        if(isLeftOrRight) isLeftOrRight = false;
        else isLeftOrRight = true;
    }
}
