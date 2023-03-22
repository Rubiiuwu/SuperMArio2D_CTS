using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundSensor : MonoBehaviour
{
    private PlayerController controller;
    public bool isGrounded;
    SFXManager SFXManager;
    SoundManager SoundManager;
    GameManager gameManager;

    void Awake() 
    {
        controller = GetComponentInParent<PlayerController>();
        SFXManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

        SoundManager.StopBGM();
        SFXManager.MarioDeath();
        //SceneManager.LoadScene(2);
        gameManager.GameOver();
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
