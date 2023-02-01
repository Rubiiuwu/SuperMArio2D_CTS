using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerController controller;
    public bool isGrounded;

    void Awake() 
    {
        controller = GetComponentInParent<PlayerController>();    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
      if (other.gameObject.layer == 3)
       {
       isGrounded = true;     
       controller.anim.SetBool("isJumping", false);
       }

       if(other.gameObject.tag == "DeadZone")
      { 
        Debug.Log("Estoy muerto");
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
