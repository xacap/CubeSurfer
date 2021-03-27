using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
    public Transform levelStartPoint;
    public List<LevelPiece> pieces = new List<LevelPiece>();
    
    public LevelPiece pieceFinish;
    private int pieceCount = 0;

    void Awake()
    { if (instance == null) { instance = this; } }

    void Start()
    {
        GenerateInitialPieces();
    }

    

    public void GenerateInitialPieces()
    {
        for (int i = 0; i < 4; i++)
        {
            AddPiece();
        }
    }

    public void AddPiece()
    {
        //int randomIndex = Random.Range(0, levelPrefabs.Count);

        LevelPiece piece = new LevelPiece();

        piece = (LevelPiece)Instantiate(levelPrefabs[pieceCount]);

        /*
         if (pieceCount == 3)
         {
             piece = (LevelPiece)Instantiate(pieceFinish);
         }
         else 
         {
             piece = (LevelPiece)Instantiate(levelPrefabs[pieceCount]);
         }
        */

        piece.transform.SetParent(this.transform, false);

        Vector3 spawnPosition = Vector3.zero;
       // Quaternion spawnRotation = new Quaternion (0,0,0,0);
        
        Vector3 offset = new Vector3 (0, 0, 12);           

        if (pieces.Count == 0)
        {
            spawnPosition = levelStartPoint.position;
        }
        else
        {
            spawnPosition = pieces[pieces.Count - 1].exitPoint.position + offset;
           // spawnRotation = pieces[pieces.Count - 1].exitPoint.rotation;
        }

       // piece.transform.rotation = spawnRotation;
        piece.transform.position = spawnPosition;
        
        pieces.Add(piece);
        pieceCount++;

        if (pieceCount >= 4)
        {
            pieceCount = 0;
        }
    }

    public void RemoveOldestPiece()
    {
        LevelPiece oldestPiece = pieces[0];
        pieces.Remove(oldestPiece);
        Destroy(oldestPiece.gameObject);
    }

}
