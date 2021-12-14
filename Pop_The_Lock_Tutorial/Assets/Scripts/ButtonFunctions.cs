using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{

    public Button pauseGameButton;
    public Button resumeGameButton;
    
    public RectTransform pausePanel;

    void Start()
    {
        pauseGameButton.onClick.AddListener(PauseGameButtonClick);
        resumeGameButton.onClick.AddListener(ResumeGameButtonClick);
    }

    public void PauseGameButtonClick()
    {
        Time.timeScale = 0;
        pausePanel.gameObject.SetActive(true);
    }
    public void ResumeGameButtonClick()
    {
        Time.timeScale =1;
        pausePanel.gameObject.SetActive(false);
    }
}
