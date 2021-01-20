using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource loop;
    public AudioClip[] music;
    public AudioClip valid;
    public GameObject canvas;
    public bool dialogue=true;
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
        if (!audio.isPlaying && !loop.isPlaying)
        {
            playNext();
        }
        if ( (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Z)||Input.GetKeyDown(KeyCode.Mouse0)) && dialogue )
        {
            canvas.SetActive(false);
            AudioSource.PlayClipAtPoint(valid, transform.position);
            dialogue=false;
        }
    }
    void playNext(){
        loop.clip=music[1];
        loop.Play();
    }
}
