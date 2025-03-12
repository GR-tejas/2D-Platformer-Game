using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainWindow;
    public GameObject levelSelectWindow;
    public GameObject[] levelButtons;

    public AudioSource audioSource;
    public AudioClip clip;

    private void Start()
    {
        mainWindow.SetActive(true);
        levelSelectWindow.SetActive(false);
        GameManagerScript.levelUnlock[0] = true;
        IsLevelUnlock();

        if (audioSource == null)
            Debug.LogError("AudioSource component is missing on " + gameObject.name);
    }
    public void OnButtonClicked(int buttonIndex)
    {
        PlayButtonSound();
        switch (buttonIndex)
        {
            case 0:
                SceneManager.LoadScene(1);
                break;
                
            case 1:
                mainWindow.SetActive(false);
                levelSelectWindow.SetActive(true);
                break;

            case 2:
                Debug.Log("Game Closed!");
                Application.Quit();
                break;

            default:
                Debug.Log("Invalid Button Index!");
                break;
        }
    }

    public void OnLevelButtonClicked(int LevelNum)
    {
        PlayButtonSound();

        if (LevelNum < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(LevelNum);
        else
            Debug.Log("Invalid Level Number");
    }

    public void IsLevelUnlock()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].SetActive(GameManagerScript.levelUnlock[i]);
        }
    }

    public void PlayButtonSound()
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is missing!");
        }
    }
}
