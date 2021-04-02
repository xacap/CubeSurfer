using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VievGames : MonoBehaviour
{
    public Text scoreLabel;


    void Update()
    {
        scoreLabel.text = GameBehavior.instance._itemsCollected.ToString("f0");
    }
}
