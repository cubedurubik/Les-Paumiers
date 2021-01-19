using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float speed;
    public int playerDamage=5;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void MoveEnemy()
    {
        int xDir = 0;
        int yDir = 0;
        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
            yDir = target.position.y > transform.position.y ? 1 : -1;
        else
            xDir = target.position.x > transform.position.x ? 1 : -1;


    }
    void OnTriggerEnter2D<T>(T component)
    {
        Player hitPlayer = component as Player;
        hitPlayer.LoseChoco(playerDamage);



    }

}
