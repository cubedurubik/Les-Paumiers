using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;
    public int wallDamage = 1;
    public int pointsPerChoco = 10;
    public float restartLevelDelay = 1f;
    public int pointsLossAttack = 1;

    private Animator animator;
    public int chocolat = 100;
    public float speed = 2;
    private Rigidbody2D rb2d;
    private BoxCollider2D boxCollider;


    private void onDisable() //re charge la valeur de la food pour le prochain lvl
    {
        GameManager.instance.playerChocoPoints = chocolat;
    }



    // Update is called once per frame



    void Start()
    {
        
        chocolat = GameManager.instance.playerChocoPoints;
        boxCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //rb2d.AddForce(movement * speed);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up*speed*Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
        }


    }



    private void OnTriggerEnter2D (Collider2D other)//permet au player d'interagir avec les autres objets
    {
    if (other.tag == "Exit")
        {
            Invoke("Restart", restartLevelDelay);
            enabled = false;
        }

    else if (other.tag == "Chocolat")
        {
            chocolat += pointsPerChoco;
            other.gameObject.SetActive(false);
        }
        
    else if (other.tag == "Wall")
        {
            other.gameObject.GetComponent<Wall>().DamageWall(wallDamage);
        }

        
    }



    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void LoseFood(int loss)
    {
        animator.SetTrigger("playerHit");
        chocolat -= loss;
        checkIfGameOver();
    }

    public void Attack()
    {
        
        animator.SetTrigger("playerAttack");
        chocolat -= pointsLossAttack;
        checkIfGameOver();
    }

    private void checkIfGameOver()
    {
        if (chocolat <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

}

