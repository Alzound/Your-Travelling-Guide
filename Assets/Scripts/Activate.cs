using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject other;
    public GameObject other1; 
    public GameObject theDoor;


    private void Update()
    {
        Enter(); 
    }

    void Enter()
    {
        if (this.gameObject.GetComponent<GrabMechanic>().bad == 1)
        {
            door1.SetActive(true);
            other.SetActive(false);
            theDoor.transform.position = new Vector3(-2121f,0f,1798.8f);
            theDoor.transform.eulerAngles = new Vector3(0,-90,0);
        }
        if(this.gameObject.GetComponent<GrabMechanic>().good == 1)
        {
            door2.SetActive(true);
            other1.SetActive(false);
            theDoor.transform.position = new Vector3(-2121f, 0f, 1798.8f);
            theDoor.transform.eulerAngles = new Vector3(0, -90, 0);
        }
    }
}
