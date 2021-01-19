using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// POUR AUGMENTER LE SCORE DE 10 : ScoreScript.scoreValue += 10;

public class ScoreScript : MonoBehaviour
{

    public static int ScoreValue = 0;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + ScoreValue;
    }
}
