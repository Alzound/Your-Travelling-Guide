using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class finalscene : MonoBehaviour
{
    public GameObject final;
    public GameObject otherUI; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(StopTimeFinal()); 
            otherUI.SetActive(false); 
            final.SetActive(true); 
            Application.Quit();
            Debug.Log("Application quit"); 
        }
    }

    IEnumerator StopTimeFinal()
    {
        yield return new WaitForSeconds(10); 
    }
}
