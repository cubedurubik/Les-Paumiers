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

    private GameManager gameM;
    private Animator animator;
    public int chocolat = 100;
    public float speed = 2;
    private Rigidbody2D rb2d;
    private BoxCollider2D boxCollider;

    public AudioSource audio;
    public AudioClip[] steps;
    public AudioClip[] shot;
    public AudioClip zoneTransfer;
    public AudioClip colision;
    public AudioClip recupItem;
    public int t=0;

    private void onDisable() //re charge la valeur de la food pour le prochain lvl
    {
        GameManager.instance.playerChocoPoints = chocolat;
    }



    // Update is called once per frame



    void Start()
    {
        gameM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
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

            if (!(Input.GetKey(KeyCode.LeftArrow)||(Input.GetKey(KeyCode.RightArrow))||(Input.GetKey(KeyCode.DownArrow))))
            {
                if (t%25==0){
                    joueStep(Random.Range(0, 6));
                }
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);

            if (!(Input.GetKey(KeyCode.LeftArrow)||(Input.GetKey(KeyCode.RightArrow))))
            {
                if (t%25==0){
                    joueStep(Random.Range(0, 6));
                }
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);

            if (!(Input.GetKey(KeyCode.LeftArrow)))
            {
                if (t%25==0){
                    joueStep(Random.Range(0, 6));
                }
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);

            if (t%25==0){
                    joueStep(Random.Range(0, 6));
                }
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (t%12==0){
                joueShot(Random.Range(0,11));
            }
        }
        t++;

    }

    void joueStep(int index)
    {
        AudioSource.PlayClipAtPoint(steps[index], transform.position);
    }
    void joueShot(int index)
    {
        AudioSource.PlayClipAtPoint(shot[index], transform.position);
    }

    private void OnTriggerEnter2D (Collider2D other)//permet au player d'interagir avec les autres objets
    {
    if (other.tag == "Exit")
        {
            transform.position = new Vector2(0,0);
            gameM.OnLevelWasLoaded();
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(zoneTransfer, transform.position);
        }

    else if (other.tag == "Chocolat")
        {
            chocolat += pointsPerChoco;
            other.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(recupItem, transform.position);
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

    public void LoseChoco(int loss)
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

