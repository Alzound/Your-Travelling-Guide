using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionsManager : MonoBehaviour
{
    private static DecisionsManager instance;
    public string objID;
    public int data;
    public int data2; 

    public static int countG = 0;
    public static int countB = 0;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject); 
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject); 
        }
    }

    private void Update()
    {
   


    }

    private void OnTriggerEnter(Collider other)
    {
     

        if(other.gameObject.tag == "GoodDecision")
        {
           
            countG++;
            data = countG; 
        }
        if(other.gameObject.tag == "BadDecision")
        {
            countB++;
            data2 = countB; 
        }
    }

    /*
    private void Awake()
    {
        objID = name + transform.position.ToString() + transform.eulerAngles.ToString(); 
    }
    */



    /*
    private void Start()
    {
        for(int i = 0; i < Object.FindObjectsOfType<DecisionsManager>().Length; i++)
        {
            if(Object.FindObjectsOfType<DecisionsManager>()[i] != this)
            {
                if(Object.FindObjectsOfType<DecisionsManager>()[i].objID == objID)
                {
                    Destroy(gameObject); 
                }
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    */
}
