using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainWindow;
    public GameObject levelSelectWindow;
    public GameObject[] levelButtons;

    private void Start()
    {
        mainWindow.SetActive(true);
        levelSelectWindow.SetActive(false);
        GameManagerScript.levelUnlock[0] = true;
        IsLevelUnlock();
    }
    public void OnButtonClicked(int buttonIndex)
    {
        switch(buttonIndex)
        {
            case 0:
                SceneManager.LoadScene(1);
                break;
                
            case 1:
                mainWindow.SetActive(false);
                levelSelectWindow.SetActive(true);
                break;

            default:
                Debug.Log("Invalid Button Index!");
                break;
        }
    }

    public void OnLevelButtonClicked(int LevelNum)
    {
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
}
