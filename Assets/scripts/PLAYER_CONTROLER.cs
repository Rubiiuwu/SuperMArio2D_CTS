using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_CONTROLER : MonoBehaviour
{
    int playerhealth = 3; 
    float playerspeed = 5.5f;
    string texto = "hello world";
    bool isGrounded = false;

    // CUM is called before the first frame update
    void CUM()
    {
        playerhealth = 10; 
        Debug.Log(texto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
