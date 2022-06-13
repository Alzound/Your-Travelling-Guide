using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSecuence : MonoBehaviour
{
    private Vector3 _initialPosition;
    
    public bool _key = false;

    public void Awake()
    {
        _initialPosition = gameObject.transform.position;
    }

 

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Loop" && _key == false)
        {
            gameObject.transform.position = _initialPosition;

        }
        

    }
}
