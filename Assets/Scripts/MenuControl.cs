using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
   public void Play()
    {
       
            Debug.Log("Enter");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void Continue()
    {

        SceneManager.LoadScene(2); 
        
    }


    public void Options()
    {
        //if()
    }

    public void Quit()
    {
       
            Application.Quit();
        
    }

}
