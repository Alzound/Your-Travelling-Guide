using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabMechanic : MonoBehaviour
{
    RaycastHit hit; 
    public int objectThis = 0;
    public Camera cameraThis;
    GameObject _selectedObj;
    Vector3 _ogPosition;
    Vector3 _ogRotation;
    Vector3 _Augmented; 
    public bool examinable = false;
    public bool _deactivate = false; 
    public bool _enter;
    public int good = 0;
    public int bad = 0; 



    private void Awake()
    {
        Ray ray = cameraThis.ScreenPointToRay(Input.mousePosition);
        _enter = true;
        _Augmented = new Vector3(-4f, 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        HasHit();

        turnAround();

        ExitExamination();
    }


    void HasHit()
    {
        if(Input.GetMouseButtonDown(0) && _enter == true)
        {
            Ray ray = cameraThis.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10f))
            {
                
                if(hit.transform.tag == "Object")
                {
                    _selectedObj = hit.transform.gameObject;

                    _ogPosition = _selectedObj.transform.position;
                    _ogRotation = _selectedObj.transform.rotation.eulerAngles;
                    _selectedObj.transform.parent = this.gameObject.transform;  
                    _selectedObj.transform.position =  cameraThis.transform.position + (transform.forward * 3.1f);


                    Time.timeScale = 0;

                    examinable = true;
                    _enter = false; 

                    
                }
                if (hit.transform.tag == "KeyGood")
                {
                    _selectedObj = hit.transform.gameObject;

                    _ogPosition = _selectedObj.transform.position;
                    _ogRotation = _selectedObj.transform.rotation.eulerAngles;
                    _selectedObj.transform.parent = this.gameObject.transform;
                    _selectedObj.transform.position = cameraThis.transform.position + (transform.forward * 3.1f);


                    Time.timeScale = 0;

                    examinable = true;
                    _enter = false;
                    _deactivate = true;
                    good++; 


                }
                if (hit.transform.tag == "KeyBad")
                {
                    _selectedObj = hit.transform.gameObject;

                    _ogPosition = _selectedObj.transform.position;
                    _ogRotation = _selectedObj.transform.rotation.eulerAngles;
                    _selectedObj.transform.parent = this.gameObject.transform;
                    _selectedObj.transform.position = cameraThis.transform.position + (transform.forward * 3.1f);


                    Time.timeScale = 0;

                    examinable = true;
                    _enter = false;
                    _deactivate = true; 
                    bad++;


                }


            }
        }
        
    }


    private void turnAround()
    {
        //This is going to rotate the object taking the movement from the camera. 
        //Also, bless Youtube.
        if (examinable)
        {
            float rotationsSpeed = 10;

            float xAxis = Input.GetAxis("Mouse X") * rotationsSpeed;
            float yAxis = Input.GetAxis("Mouse Y") * rotationsSpeed;

            _selectedObj.transform.Rotate(Vector3.up, xAxis, Space.World);
            _selectedObj.transform.Rotate(Vector3.right, yAxis, Space.World);
        }
    }



    private void ExitExamination()
    {
        //With this when the player clicks the right button of the mouse the object returns to it's original position.
        if (Input.GetMouseButtonDown(1) && examinable)
        {
            _selectedObj.transform.position = _ogPosition;
            _selectedObj.transform.eulerAngles = _ogRotation;

            Time.timeScale = 1;
            examinable = false;
            _enter = true; 
            _selectedObj.transform.SetParent(null);            
        }

        if (Input.GetMouseButtonDown(1) && examinable && _deactivate == true)
        {
            _selectedObj.transform.position = _ogPosition;
            _selectedObj.transform.eulerAngles = _ogRotation;

            Time.timeScale = 1;
            examinable = false;
            _enter = true;
            _selectedObj.SetActive(false); 
            _selectedObj.transform.SetParent(null);
            _deactivate = false; 
        }

    }
}
