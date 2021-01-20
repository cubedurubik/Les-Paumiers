using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource loop;
    public AudioClip[] music;

    // Start is called before the first frame update

    void Awake()
    {
        audio.clip=music[0];
        audio.Play();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            playNext();
        }
    }
    void playNext(){
        loop.clip=music[1];
        loop.Play();
    }
}
