using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerController controller;
    public bool isGrounded;
    SFXManager SFXManager;

    void Awake() 
    {
        controller = GetComponentInParent<PlayerController>();
        SFXManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
      if (other.gameObject.layer == 3)
       {
       isGrounded = true;     
       controller.anim.SetBool("isJumping", false);
       }
       else if (other.gameObject.layer == 6)
       {
        Debug.Log("goomba muerto");

        SFXManager.GoombaDeath();
        
        enemy goomba = other.gameObject.GetComponent<enemy> ();
        goomba.Die();
        
       }

       if(other.gameObject.tag == "DeadZone")
      { 
        Debug.Log("Estoy muerto");

        SFXManager.MarioDeath();
      }

    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.layer == 3)
       {
       isGrounded = true;     
       controller.anim.SetBool("isJumping", false);
       }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
      if (other.gameObject.layer == 3)
      {
        isGrounded = false;
        controller.anim.SetBool("IsJumping", true);
      }

    }
}
