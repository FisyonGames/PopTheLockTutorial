using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{
    public Transform dot;
    public Transform capsuleShape;

    public bool isReadyForPoint;
    //public bool isClickMouseButton;

    private Dot m_dot;
    private CapsuleShape m_capsuleShape;

    void Awake()
    {
        m_dot = dot.gameObject.GetComponent<Dot>();
        m_capsuleShape = capsuleShape.gameObject.GetComponent<CapsuleShape>();
    }

    void Start()
    {
        //isClickMouseButton = false;  
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //isClickMouseButton = true;
            if(isReadyForPoint)
            {
                SetCount();
            }
            else
            {
                Fail();
            }
        }
    }

    void SetCount()
    {
        print("SAYIIIII......");
        //Destroy(dot.gameObject);
        //dot.gameObject.SetActive(false);
        m_capsuleShape.ChangeRotateDirection();
        //dot.gameObject.SetActive(true);
        m_dot.CreateNewDotRotation();
        //isClickMouseButton = false;
    }

    public void Fail()
    {
        print("MISS.......");
        PauseGame();  
        //isClickMouseButton = false;  
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale =1;
    }
}
