using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public Text coinText;
    int coins;

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


    IEnumerator LoadScene ()
    {
        //Esto para la corutina durante 2.5s
        yield return new WaitForSeconds(2.5f);
        
        SceneManager.LoadScene(2);
    }

    /*public void AddCoin() 
    {
        coin++;
        coinText.text = coins.ToString();
    }
    */

}
