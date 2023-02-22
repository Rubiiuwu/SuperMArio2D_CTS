using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Animator anim;
    BoxCollider2D boxCollider;
    SFXManager sfxManager;
    
    // Start is called before the first frame update

    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }
   
    public void Pick()
    {
        boxCollider.enabled = false;
        Destroy(this.gameObject);
        sfxManager.Coin();
    }

    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "CollisionCoin")
        {
            Destroy(colision.gameObject);
            sfxManager.Coin();
        }
    }
}