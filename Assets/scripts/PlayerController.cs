using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int playerHealth = 3;
    int contadorMonedas;
    public float playerSpeed = 5.5f;
    string texto = "Hello World";
    private SpriteRenderer spriteRenderer;
    float horizontal;
    private Rigidbody2D rBody; 
    public float jumpForce = 3f;
    private GroundSensor sensor;
    public Animator anim;
    private Coin coin;
    public SFXManager sfxManager;
    private Bandera flag;
    BoxCollider2D boxCollider;
    public Text textoContador;
    GameManager gameManager;
    public GameObject bulletPrefab;
//Variable para posicionar hacia donde se dispara el prefab/la bullet
    public Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        contadorMonedas = 0;
        playerHealth = 10;
        Debug.Log(texto);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager .isGameOver == false);
        {

        horizontal = Input.GetAxis("Horizontal");

        //transform.position += new Vector3(horizontal, 0, 0) * playerSpeed * Time.deltaTime;

        if (horizontal < 0)
            {
                //spriteRenderer.flipX = true;
                transform.rotation = Quaternion.Euler(0, 180 ,0);
                anim.SetBool("IsRunning", true);
            } else if (horizontal > 0)
                {
                    //spriteRenderer.flipX = false;
                    transform.rotation = Quaternion.Euler(0, 0 ,0);
                    anim.SetBool("IsRunning", true);
                } else{
                    anim.SetBool("IsRunning", false);
                }
        if (Input.GetButtonDown("Jump") && sensor.isGrounded)
            {
                rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetBool("IsJumping", true);
            }    
        if(Input.GetKeyDown(KeyCode.F) && gameManager.canShoot)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
        }
    }

    void FixedUpdate() 
    {
        rBody.velocity = new Vector2 (horizontal*playerSpeed, rBody.velocity.y);
    }

      void OnTriggerEnter2D (Collider2D collider)
      {
        if(collider.gameObject.tag == "powerup")
        {
            gameManager.canShoot = true;
            Destroy(collider.gameObject);
        }
      }

      void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "CollisionCoin")
        {
            contadorMonedas = contadorMonedas + 1;
            Debug.Log(contadorMonedas);
            textoContador.text = "monedas " + contadorMonedas;
        }
    }

    /*void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Coin")
        {
            gameManager.AddCoin();
            Destroy(collider.gameObject);
        }
    }*/

}
