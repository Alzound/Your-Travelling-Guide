using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleGood : MonoBehaviour
{
    public GameObject wave;
    public Material mat; 

    private void Awake()
    {
        wave.GetComponent<Renderer>().material = mat;
        wave.GetComponent<Waves>().amplitudeV = 2;
        wave.GetComponent<Waves>().limit = 5;
    }
}
