using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public void ShowGameFinishWindow(EPlayerState playerState)
    {
        GameObject _go = Instantiate(Resources.Load("UI")) as GameObject;
        _go.GetComponent<WindowGameFinish>().Show(playerState);

    }
   
}
