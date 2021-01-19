using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public float speed=1;
    public GameObject projectile;
    public int hp = 5;
    //public static Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta);
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime); 
       /* int xDir = 0;
        int yDir = 0;
        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
            yDir = target.position.y > transform.position.y ? 1 : -1;
        else
            xDir = target.position.x > transform.position.x ? 1 : -1;

        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        transform.Translate(Vector2.up * xDir*speed * Time.fixedDeltaTime);
        transform.Translate(Vector2.left * yDir*speed * Time.fixedDeltaTime);
*/
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Weapon")
        {
            hp -= 5;
            if (hp <= 0)
            {
                enabled = false;

            }
        }
    }






}
