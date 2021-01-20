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
    [SerializeField]
    private List<Enemy> enemies;
    public AudioSource audio;
    public AudioClip clip;

    public int GetLevel()
    {
        return level;
    }

    void Start()
    {
        
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

    public void OnLevelWasLoaded()
    {
        level++;
        InitGame();
    }

    public void Supp()
    {
        if (player.enabled == true)
        {
            Debug.Log("accessIf");
            foreach (GameObject enemy in boardScript.enemyTiles)
            {
                Debug.Log("accessForeach : "+ enemy);
                /*enemy.GetComponent<Enemy>().GameOver();*/
            }

        }
    }


    void InitGame()
    {
        boardScript.SetupScene(level);

    }
    public void AddEnemyToList(Enemy script)
    {
        enemies.Add(script);
    }

    void Update()
    {
        

    }
}
