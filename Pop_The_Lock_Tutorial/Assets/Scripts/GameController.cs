using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour{
    public Transform dot, dotSprite, capsuleShape, cam;
    public Text scoreText, bestScoreText;
    public bool isReadyForPoint;
    public bool isGamePlayed;

    private Dot m_dot;
    private CapsuleShape m_capsuleShape;
    private DotSpriteCollider m_dotSpriteCollider;
    private CameraFailMovement m_cameraFailMovement;
    private BackgroundColor m_backgroundColor;

    private int count = 0;
    private int bestScore;
    

    void Awake()
    {
        m_dot = dot.gameObject.GetComponent<Dot>();
        m_capsuleShape = capsuleShape.gameObject.GetComponent<CapsuleShape>();
        m_dotSpriteCollider = dotSprite.gameObject.GetComponent<DotSpriteCollider>();
        m_cameraFailMovement = cam.GetComponent<CameraFailMovement>();
        m_backgroundColor = cam.GetComponent<BackgroundColor>();

        m_cameraFailMovement.enabled = false;
        m_capsuleShape.enabled = false;
    }

    void Start()
    {
        isReadyForPoint = false;
        isGamePlayed = false;

        bestScore = PlayerPrefs.GetInt("bestScore");
        count = 0;
        SetCountText();
        //PlayerPrefs.DeleteKey("highScore");
        
        m_dot.CreateNewDotRotation();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Input.mousePosition.y < Screen.height/2 && isGamePlayed)
        {
            if(isReadyForPoint)
            {
                m_dotSpriteCollider.insider = true;
                SetCount();
            }
            else
            {
                Fail();
            }
        }
        if(Input.GetMouseButtonDown(0) && Input.mousePosition.y < Screen.height/2 && !isGamePlayed)
        {
            m_capsuleShape.enabled = true;
            isGamePlayed = true;
        }
    }

    void SetCount()
    {
        count++;
        SetCountText();
        m_capsuleShape.ChangeRotateDirection();
        m_dot.CreateNewDotRotation();
        isReadyForPoint = false;
    }

    public void Fail()
    {
        print("....");
        m_capsuleShape.enabled = false;     //Capsule'ün hareketi durduruluyor ve camera final hareketi başlatılıyor.
        m_backgroundColor.ChangeBackgroundColor();
        m_cameraFailMovement.enabled = true;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isReadyForPoint = false;
    }

    void SetCountText()
	{
		scoreText.text = count.ToString();
		if (count >= bestScore) 
		{
            PlayerPrefs.SetInt("bestScore", count);
            PlayerPrefs.Save();
		}
        bestScoreText.text = "Best: " + PlayerPrefs.GetInt("bestScore").ToString();
	}
}
