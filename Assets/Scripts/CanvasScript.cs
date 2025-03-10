using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public TextMeshProUGUI CollectablesCount;
    public TextMeshProUGUI LevelNum;
    GameObject gameOverWindow;

    [SerializeField] GameManagerScript gameManagerScript;

    private void Start()
    {
        gameOverWindow = transform.Find("GameOver").gameObject;
    }

    public void CollectablesCountUpdate(int count)
    {
        CollectablesCount.text = "Keys = " + count;
    }

    public void LevelNumberUpdate(int levelNumber)
    {
        LevelNum.text = "Level: " + levelNumber;
    }

    public void ToggleGameOverUI(bool choice)
    {
        gameOverWindow.SetActive(choice);
    }

    public void OnButtonClick(int buttonNum)
    {
        gameManagerScript.LoadScene((SceneNumber)buttonNum);
    }
}
/*int FuncB()
 * int b = gameManagerScript.FuncA();
 * return a;
 */