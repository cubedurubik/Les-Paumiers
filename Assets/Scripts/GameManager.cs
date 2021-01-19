using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    private BoardManager boardScript;
    private int level = 3;
    public float levelStartDelay = 2f;
    public int playerChocoPoints = 100;

    void Awake()
    {
        
        if (instance == null)
            instance = this;

        
        else if (instance != this) 
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void OnLevelWasLoaded(int index)
    {
        level++;
        InitGame();
    }
    public void GameOver()
    {
        enabled = false;
    }

    void InitGame()
    {
        boardScript.SetupScene(level);

    }

    void Update()
    {

    }
}
