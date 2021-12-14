using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpriteCollider : MonoBehaviour
{
    public Transform gameController;
    private GameController m_gameController;

    public bool insider;

    void Start()
    {
        m_gameController = gameController.gameObject.GetComponent<GameController>();
        //insider = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "CapsuleShape")
        {
            m_gameController.isReadyForPoint = true;
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "CapsuleShape")
        {
            m_gameController.isReadyForPoint = true;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "CapsuleShape" && !insider)
        {
            //m_gameController.isReadyForPoint = false;
            m_gameController.Fail();
            //gameObject.SetActive(false);
        }
        if(insider)
        {
            insider = false;
            m_gameController.isReadyForPoint = false;
        }
    }
    /*
    void OnDisable()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        insider = false;
    }
    */
}
