using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }

    }

    public int columns = 8;
    public int rows = 8;
    public Count wallCount = new Count(8, 15);
    public Count foodCount = new Count(1, 2);
    public GameObject exit;
    public GameObject player;
    public GameObject[] floorTiles;
    public GameObject[] outerWallTiles;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] enemyTiles;
    public GameObject map;
    public int enemyCount;
    public List<GameObject> enemyInstantiate = new List<GameObject>();

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitialiseList()  //efface les anciens et prepare les emplacements pour les objects
    {
        gridPositions.Clear();

        for (int x = 0; x < columns - 1; x++)
        {
            for (int y = 0; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup() //set up les bords et le sol
    {
        boardHolder = new GameObject("Board").transform;
        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                }

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);

            }
        }
    }

    Vector3 RandomPosition() //retourne une position aléatoire
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int min, int max, int index) //choisi aléatoirement les objets a placer 
    {
        int objectCount = Random.Range(min, max + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            GameObject objet = Instantiate(tileChoice, randomPosition, Quaternion.identity);
            objet.transform.SetParent(map.transform);
            if (index == 1)
            {
                enemyInstantiate.Add(objet);
            }
        }
    }
    public void SetupScene(float level)// en gros c'est le main
    {
        if (map != null)
        {
            Destroy(map);
            map = Instantiate(new GameObject ("map"));
        }
        else
        {
            map = Instantiate(new GameObject("map"));
        }
        
        BoardSetup();
        InitialiseList();
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum, 0);
        LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximum, 0); 
        enemyCount = (int)(level * 0.5f);
        Instantiate(player, new Vector3(0, 0, 0f), Quaternion.identity);
        LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount, 1);
        StartCoroutine(CoroutineExit());
          
        

        
    }

    IEnumerator CoroutineExit()
    {
        yield return new WaitUntil(() => enemyInstantiate.Count == 0);
        Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }
}