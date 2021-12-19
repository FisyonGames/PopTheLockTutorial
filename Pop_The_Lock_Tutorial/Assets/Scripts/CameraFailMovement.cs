using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFailMovement : MonoBehaviour
{

    public float speed;
    public Transform gameController;

    private Quaternion from;
    private Quaternion to;
    private float timeCount = 0.0f;
    private float timeCount_02 = 0.0f;
    private GameController m_gameController;

    void Awake()
    {
        m_gameController = gameController.gameObject.GetComponent<GameController>();
    }
    void Start()
    {
        from = Quaternion.identity;
        to.eulerAngles = new Vector3(0f, 0f, 10.0f);
    }
    void Update()
    {   
        if(timeCount <= 1.0f)
        {
            transform.rotation = Quaternion.Slerp(from, to, timeCount);
            timeCount = timeCount + Time.deltaTime * speed;
        }
        if(timeCount > 1.0f)
        {
            transform.rotation = Quaternion.Slerp(to, from, timeCount_02);
            timeCount_02 = timeCount_02 + Time.deltaTime * speed;
        }
        if(timeCount > 1.0f && timeCount_02 > 1.0f && Time.timeScale != 0)
        {
            m_gameController.PauseGame();
        }
        
    }

}
