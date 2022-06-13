using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    public int count;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {


            count++;
        }
        
    }
}
