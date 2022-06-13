using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Decisions2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && this.gameObject.tag == "GoodDecision")
        {
            SceneManager.LoadScene(2);
        }

        if (other.gameObject.tag == "Player" && this.gameObject.tag == "BadDecision")
        {
            SceneManager.LoadScene(2);
        }
    }

}