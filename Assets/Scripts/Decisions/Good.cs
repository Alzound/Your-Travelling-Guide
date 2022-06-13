using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Good : MonoBehaviour
{
    public GameObject wave;
    public Material mat;

    private void Awake()
    {
        wave.GetComponent<Renderer>().material = mat;
    }
}
