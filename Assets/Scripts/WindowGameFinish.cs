using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WindowGameFinish : MonoBehaviour
{

    public void Restart()
    {
        Destroy(this.gameObject);

        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    void Start()
    {
        GameObject panelNode = gameObject.transform.Find("Canvas/Panel").gameObject;
        GameObject obj = panelNode.transform.Find("Button").gameObject;
        Button button = obj.GetComponent<Button>();
        button.onClick.AddListener(() => Restart());
    }
    public void Show(EPlayerState winnerBoxState)
    {
        Text winText = GameObject.Find("Canvas/Panel/Text").GetComponent<Text>();

        switch (winnerBoxState)
        {
            case EPlayerState.ePlayerWinner:
                winText.text = "ФИНИШ!";
                break;
            case EPlayerState.ePlayerLost :
                winText.text = "ты умер :(";
                break;
            
        }
    }
   
}
