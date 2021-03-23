using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour, IManager
{
    private string _state;
    private UIController _UIController = new UIController();


    public string State
    {
        get { return _state;  }
        set { _state = value; }
    }

    private int _itemsCollected = 0;

   
    public void GameFinish()
    {
        Time.timeScale = 0f;

        _UIController.ShowGameFinishWindow(EPlayerState.ePlayerLost);

    }

    public int Items
    {
        get { return _itemsCollected; }

        set
        {
            _itemsCollected = value;
            
        }
    }

   

    void Start()
    {
        Initialize();

        InventoryList<string> inventoryList = new
        InventoryList<string>();
      
      
    }

    

    public void Initialize()
    {
        Debug.Log(_state);
    }
    
    void OnGUI()
    {
        GUI.Box(new Rect(20, 50, 300, 100), "Золото : " + _itemsCollected);

        

        
    }

}
