using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public bool canShoot;
    public float powerUpDuration = 5;
    public float powerUpTimer = 0;
    public Text coinText;
    int coins;
    //lo de abajo es para limitar el spawn de enemigos
    public List<GameObject> enemiesInScreen = new List<GameObject>();
    

//importante poner "Update" en mayusc porque sino se detecta como nueva función y no hace referéncia.
    void Update ()
    {
        ShootPowerUp();

        if (Input.GetKeyDown(KeyCode.P))
        {
            KillAllEnemies();
        }
    }

    public void GameOver ()
    {
        isGameOver = true;
        //LLamar función de forma normal = LoadScene();
        //Invoke ("LoadScene", 1.5f);=invocamos la función después de 1.5 s
        
        StartCoroutine ("LoadScene");
        //Llamamos a la corutina LoadScript
    }

    /*void LoadScene()
    {
        SceneManager.LoadScene(2);
    }*/

    void KillAllEnemies()
    {
        for (int i = 0; i < enemiesInScreen.Count; i++)
        {
            Destroy (enemiesInScreen[i]);
        }       
    }


    IEnumerator LoadScene ()
    {
        //Esto para la corutina durante 2.5s
        yield return new WaitForSeconds(2.5f);
        
        SceneManager.LoadScene(2);
    }

    void ShootPowerUp()
    {
        if (canShoot)
        {
            if (powerUpTimer <= powerUpDuration)
            {
                powerUpTimer += Time.deltaTime;
            }
            
            else 
            {
                canShoot = false;
                powerUpTimer = 0;
            }
        }
    }

    


    /*public void AddCoin() 
    {
        coin++;
        coinText.text = coins.ToString();
    }
    */

}
