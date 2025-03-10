using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public GameManagerScript gameManagerScript;
    public void TriggerResponse(string tag)
    {
        if (tag == "Finish")
        {
            gameManagerScript.OnLevelComplete();
        }

        if (tag == "KillPlayer")
        {
            gameManagerScript.KillPlayer();
        }

        if(tag == "Collectable")
        {
            gameManagerScript.IncreaseCount(0);
        }
    }
}
