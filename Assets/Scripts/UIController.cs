using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public void ShowGameFinishWindow(EPlayerState playerState)
    {
        GameObject _go = GameObject.Find("GameOverCanvas");
            
        _go.GetComponent<WindowGameFinish>().Show(playerState);

    }
    public void ShowLevelPassWindow(EPlayerState playerState)
    {
        GameObject _go = GameObject.Find("LevelPassCanvas");

        _go.GetComponent<WindowLevelPass>().Show(playerState);

    }

}
