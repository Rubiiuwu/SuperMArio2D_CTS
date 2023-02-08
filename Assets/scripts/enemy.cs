using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    float horizontal = 1;
    Animator anim;
    BoxCollider2D boxCollider;
    Rigidbody2D rBody;
    
    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();
        boxCollider = GetComponent <BoxCollider2D>();
        rBody = GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      rBody.velocity = new Vector2(horizontal * speed, rBody.velocity.y); 
    }

        public void Die ()
     {
        anim.SetBool("IsDead", true);
        boxCollider.enabled = false;
        Destroy(this.gameObject, 0.5f);
        }

    void OnCollisionEnter2D(Collision2D colision) 
    {
        if(colision.gameObject.tag == "Player")
        {
            Debug.Log("Mario muerto");
            Destroy(colision.gameObject);
        }

        if(colision.gameObject.tag == "ColisionGoomba")
        {
           if(horizontal == 1)

           {
            horizontal = -1;
           }
           else
           {
            horizontal = 1;
           }
        }
        
    }

   
 }