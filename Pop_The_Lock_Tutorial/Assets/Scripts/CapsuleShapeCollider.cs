using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleShapeCollider : MonoBehaviour
{
    public Transform gameController;
    private GameController m_gameController;

    void Start()
    {
        m_gameController = gameController.gameObject.GetComponent<GameController>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "DotSprite")
        {
            m_gameController.isReadyForPoint = true;
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "DotSprite")
        {
            m_gameController.isReadyForPoint = true;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "DotSprite")
        {
            m_gameController.isReadyForPoint = false;
        }
    }
}
