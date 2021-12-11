using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpriteCollider : MonoBehaviour
{
    public Transform gameController;
    private GameController m_gameController;

    private bool insider;

    void Start()
    {
        m_gameController = gameController.gameObject.GetComponent<GameController>();
        insider = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "CapsuleShape")
        {
            m_gameController.isReadyForPoint = true;
            insider = true;
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
        if(coll.gameObject.tag == "CapsuleShape" && insider)
        {
            //m_gameController.isReadyForPoint = false;
            //m_gameController.Fail();
            gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        insider = false;
    }
}