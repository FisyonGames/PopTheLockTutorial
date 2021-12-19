using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleShape : MonoBehaviour
{
    public Transform ring, dot;

    [SerializeField]
    private bool isLeftOrRight; // true is right, false is left...
    
    [SerializeField]
    private float rotationSpeed;

    void OnEnable()
    {
        isLeftOrRight = dot.rotation.eulerAngles.z <= 180.0f ? false : true;
        rotationSpeed = PlayerPrefs.GetInt("level") == 1 ? 50 : 150;
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
        isLeftOrRight = isLeftOrRight ? false : true;
    }
}
