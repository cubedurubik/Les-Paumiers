using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    private BoardManager boardScript;
    public int level = 1;
    public float levelStartDelay = 2f;
    public int playerChocoPoints = 100;
    public Player player;

    public int GetLevel()
    {
        return level;
    }

    void Start()
    {
        if (level != 1)
        {
            Destroy(gameObject);
        }
    }
    void Awake()
    {
        
        if (instance == null)
            instance = this;

        
        else if (instance != this) 
            Destroy(gameObject);
        
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
