using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2DecisionManager : MonoBehaviour
{
    public GameObject good;
    public GameObject bad;
    public GameObject player;

    private void Update()
    {
        endLevel(); 
    }

    void endLevel()
    {
        if (player.GetComponent<GrabMechanic>().good > 1)
        {
            SceneManager.LoadScene(2);
            good.SetActive(true);
        }
        if(player.GetComponent<GrabMechanic>().bad > 1)
        {
            SceneManager.LoadScene(2);
            bad.SetActive(true); 
        }
    }
  
}
