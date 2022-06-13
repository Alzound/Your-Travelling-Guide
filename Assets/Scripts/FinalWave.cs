using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalWave : MonoBehaviour
{
    public GameObject wave;
    public Material mat;

    private void Awake()
    {
        wave.GetComponent<Renderer>().material = mat;
        wave.GetComponent<Waves>().amplitudeV = 7;
        wave.GetComponent<Waves>().limit = 12;
    }
    
}
