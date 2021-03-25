using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum EGameState
{ 
    start,
    inGame,
    levelPass,
    gameOver
}

public class GameBehavior : MonoBehaviour, IManager
{
    public static GameBehavior instance;


    private string _state;
    private UIController _UIController = new UIController();

    public Canvas startCanvas;
    public Canvas inGameCanvas;
    public Canvas levelPassCanvas;
    public Canvas gameOverCanvas;

    public int _itemsCollected = 0;
    public EGameState currentGameState = EGameState.start;


    void Awake() 
    {
        if (instance == null) {instance = this;}
    }

    void Start()
    {
        currentGameState = EGameState.start;

        Initialize();
        InventoryList<string> inventoryList = new
        InventoryList<string>();

    }

    public string State
    {
        get { return _state;  }
        set { _state = value; }
    }
    public void StartGame()
    {
        SetGameState(EGameState.inGame);
    }
   
    public void LevelPassed()
    {
        Time.timeScale = 0f;
        SetGameState(EGameState.levelPass);
        _UIController.ShowLevelPassWindow(EPlayerState.ePlayerWinner);

    }

    public void GameFinish()
    {
        Time.timeScale = 0f;
        SetGameState(EGameState.gameOver);

        _UIController.ShowGameFinishWindow(EPlayerState.ePlayerLost);

    }

    void SetGameState(EGameState newGameState)
    {
        if (newGameState == EGameState.start)
        {
            startCanvas.enabled = true;
            inGameCanvas.enabled = false;
            levelPassCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == EGameState.inGame)
        {
            startCanvas.enabled = false;
            inGameCanvas.enabled = true;
            levelPassCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == EGameState.levelPass)
        {
            startCanvas.enabled = false;
            inGameCanvas.enabled = false;
            levelPassCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == EGameState.gameOver)
        {
            startCanvas.enabled = false;
            inGameCanvas.enabled = false;
            levelPassCanvas.enabled = false;
            gameOverCanvas.enabled = true;
        }
        

        currentGameState = newGameState;
    }

    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
        }
    }

    public void Initialize()
    {
        Debug.Log(_state);
    }
    
   

}
