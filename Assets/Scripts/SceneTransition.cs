using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "Portal")
            {
                SceneManager.LoadScene(3);
            }
            if (this.gameObject.tag == "Portal2")
            {
      
                SceneManager.LoadScene(4);
            }
        }
    }
}
