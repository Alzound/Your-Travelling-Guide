using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject _goSwitch;
    public Material _mtlOn;
    public Door _scrDoor;

    public void ActivateSwitch()
    {
        _goSwitch.GetComponent<Renderer>().material = _mtlOn;
        _scrDoor.OpenDoor();
    }
}
