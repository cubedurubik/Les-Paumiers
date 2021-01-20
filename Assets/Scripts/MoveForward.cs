using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;
   
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * Time.fixedDeltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.collider.tag == "Wall" )|| (other.collider.tag == "OuterWall"))
        {
            Destroy(gameObject);
        }
        
        
    }
}
