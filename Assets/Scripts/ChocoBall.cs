using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChocoBall : MonoBehaviour
{
    public static ChocoBall instance;
    public Player player;
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
