using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class Menu:MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // we can also do that by using scene name: SceneManager.LoadScene("your scene name")
    }

    public void Quit()
    {
        Application.Quit();   // not able to quit the game now, so we can use debug log to check this function working
        Debug.Log("You Have quit the game!!!");
    }
}
