using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_CONTROLER : MonoBehaviour
{
    int playerhealth = 3; 
    public float playerspeed = 5.5f;
    public float jumpForce = 3f;

    string texto = "hello world";

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody;
    private GroundSensor sensor;
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent <SpriteRenderer> (); 
        rBody = GetComponent <Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor") .GetComponent<GroundSensor>();

        playerhealth = 10; 
        Debug.Log(texto);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis ("Horizontal") ;

        transform.position += new Vector3 (horizontal,0,0)* playerspeed * Time.deltaTime;

        if (horizontal < 0)
        {
            spriteRenderer .flipX = true;
        } else if (horizontal>0) 
        {
            spriteRenderer .flipX = false;
        }
       
       if(Input.GetButtonDown ("Jump") && sensor.isGrounded)
       {
         rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }
} 
