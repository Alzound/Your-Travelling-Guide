using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleTransition : MonoBehaviour
{
    public GameObject Player;
    public GameObject door;
    public GameObject door2;
    public GameObject doorT;
    public GameObject doorT1;
    public GameObject gManager;
    public GameObject bManager; 
    public GameObject mG;
    public GameObject G;
    public GameObject B;
    public GameObject mB; 

    public int countGood = 0;
    public int countBad = 0; 

    private void Awake()
    {
        countGood = DecisionsManager.countG;
        countBad = DecisionsManager.countB; 
    }

    private void Update()
    {
        ChangeTransition();
    }

   void ChangeTransition()
    {
        if (gManager.gameObject.tag == "Good_Manager")
        {
            if (countGood == 1)
            {
                Debug.Log("MG Active");
                Player.transform.position = new Vector3(9.61f, 54.02f, 23.1f);
                Player.transform.eulerAngles = new Vector3(0,118,0);
                mG.SetActive(true);
                door.SetActive(false);
                doorT.SetActive(false);
            }
            if (countGood == 2)
            {
                Debug.Log("G Active");
                Player.transform.position = new Vector3(-0.92f, 122.3f, -63.7f);
                Player.transform.eulerAngles = new Vector3(0, 39, 0);
                G.SetActive(true);
                door2.SetActive(false);
                doorT1.SetActive(false);
            }
        }

        if (bManager.gameObject.tag == "Bad_Manager")
        {
            if (countBad == 1)
            {
                Debug.Log("mB Active");
                Player.transform.position = new Vector3(9.61f, 54.02f, 23.1f);
                Player.transform.eulerAngles = new Vector3(0, 118, 0);
                mB.SetActive(true);
                door.SetActive(false); 
            }
            if (countBad == 2)
            {
                Debug.Log("B Active");
                Player.transform.position = new Vector3(-0.92f, 122.3f, -63.7f);
                Player.transform.eulerAngles = new Vector3(0, 39, 0);
                B.SetActive(true);
                door2.SetActive(false); 
            }
        }
    }
  

}
