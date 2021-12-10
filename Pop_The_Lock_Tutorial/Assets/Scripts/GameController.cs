using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{
    public Transform dot;
    public Transform capsuleShape;

    public bool isReadyForPoint;

    private Dot m_dot;
    private CapsuleShape m_capsuleShape;

    void Awake()
    {
        m_dot = dot.gameObject.GetComponent<Dot>();
        m_capsuleShape = capsuleShape.gameObject.GetComponent<CapsuleShape>();
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(isReadyForPoint)
            {
                print("SAYIIIII......");
                m_dot.CreateNewDotRotation();
                m_capsuleShape.ChangeRotateDirection();
            }
            else
            {
                print("MISS.......");
                Time.timeScale = 0;     //Pause game...
            }
        }
    }
}
