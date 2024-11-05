using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private GameObject pausePanel;

    private bool isPaused = false;

    void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        quitButton.onClick.AddListener(ExitPlayMode);

        Debug.Log(pausePanel.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
            
            if(!pausePanel.activeSelf)
            {
                pausePanel.SetActive(true);

            } else if(pausePanel.activeSelf)
            {
                pausePanel.SetActive(false);
            }
        }
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();
    }

    private void OnPlayButtonClicked()
    {
        if (pausePanel.activeSelf)
        {
            TogglePause();
            pausePanel.SetActive(false);
        }
    }

    private void ExitPlayMode()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    private void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;

        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
        }
    }
}
