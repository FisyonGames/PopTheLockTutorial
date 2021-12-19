using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour{
    public Transform dot, dotSprite, capsuleShape, cam, shank, ring;
    public Text scoreText, levelText, informationText;
    public AnimationClip shankAnim, shankAnim_2;
    public bool isReadyForPoint, isGamePlayed, isGamePaused;

    private Dot m_dot;
    private CapsuleShape m_capsuleShape;
    private DotSpriteCollider m_dotSpriteCollider;
    private CameraFailMovement m_cameraFailMovement;
    private BackgroundColor m_backgroundColor;

    private Animator shankAnimator, ringAnimator, scoreAnimator;

    private int count = 0;
    private int maxLevel = 100;

    void Awake()
    {
        m_dot = dot.gameObject.GetComponent<Dot>();
        m_capsuleShape = capsuleShape.gameObject.GetComponent<CapsuleShape>();
        m_dotSpriteCollider = dotSprite.gameObject.GetComponent<DotSpriteCollider>();
        m_cameraFailMovement = cam.GetComponent<CameraFailMovement>();
        m_backgroundColor = cam.GetComponent<BackgroundColor>();

        shankAnimator = shank.GetComponent<Animator>();
        ringAnimator = ring.GetComponent<Animator>();
        scoreAnimator = scoreText.GetComponent<Animator>();

        m_cameraFailMovement.enabled = false;
        m_capsuleShape.enabled = false;
    }

    void Start()
    {
        Time.timeScale = 1;

        isReadyForPoint = false;
        isGamePlayed = false;
        isGamePaused = false;

        count = 0;
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") <= 0 ? 1 : (PlayerPrefs.GetInt("level") > maxLevel ? maxLevel : PlayerPrefs.GetInt("level")));
        scoreText.text = count.ToString();
        levelText.text = "Level: " + PlayerPrefs.GetInt("level").ToString();
        //PlayerPrefs.DeleteKey("level");

        m_dot.CreateNewDotRotation();

        if(PlayerPrefs.GetInt("level") == 1)
        {
            informationText.enabled = true;
            scoreText.enabled = false;
        }
        else
        {
            informationText.enabled = false;
            scoreText.enabled = true;
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Input.mousePosition.y < Screen.height/2 && isGamePaused)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        else if(Input.GetMouseButtonDown(0) && Input.mousePosition.y < Screen.height/2 && isGamePlayed)
        {
            if(isReadyForPoint)
            {
                m_dotSpriteCollider.insider = true;
                Point();
            }
            else
            {
                Fail();
            }
        }
        else if(Input.GetMouseButtonDown(0) && Input.mousePosition.y < Screen.height/2 && !isGamePlayed)
        {
            m_capsuleShape.enabled = true;
            isGamePlayed = true;
        }
        /* else{} */

        if(informationText  && isGamePlayed)
        {
            informationText.enabled = false;
            scoreText.enabled = true;
        }
    }

    void Point()
    {
        count++;
        scoreText.text = count.ToString();

		if (count == PlayerPrefs.GetInt("level")) 
		{
            PlayerPrefs.SetInt("level", count + 1 > maxLevel ? maxLevel : count + 1);
            PlayerPrefs.Save();
            Passed();
		}
        else
        {
            m_capsuleShape.ChangeRotateDirection();
            m_dot.CreateNewDotRotation();
            isReadyForPoint = false;
        }
    }

    public void Fail()
    {
        m_capsuleShape.enabled = false;
        m_backgroundColor.ChangeBackgroundColor();
        m_cameraFailMovement.enabled = true;
        isGamePaused = true;
    }

    public void Passed()
    {
        m_capsuleShape.enabled = false;
        dotSprite.GetComponent<SpriteRenderer>().enabled = false;
        capsuleShape.GetComponent<SpriteRenderer>().enabled = false;

        isGamePaused = true;

        StartCoroutine(AnimCoroutine());
    }

    IEnumerator AnimCoroutine()
    {
        shankAnimator.Play("Shank_Anim");
        scoreAnimator.Play("Score_Anim");

        yield return new WaitForSeconds(shankAnim.length);

        scoreText.enabled = false;
        levelText.text = "Level: " + PlayerPrefs.GetInt("level").ToString();

        shankAnimator.Play("Shank_Anim_2");
        ringAnimator.Play("Ring_Anim");

        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        isReadyForPoint = false;
    }

}
