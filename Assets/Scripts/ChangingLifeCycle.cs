using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingLifeCycle : MonoBehaviour
{
    //Public variables
    #region
    const float upper = 45.3f;
    private float x, y, z; 
    public float _alttitude = 0;
    public float _newAlttitude = 0;
    public Vector3 _newScale; 

    private Light _thisLight; 
    #endregion

    //Public Gameobject 
    #region
    public GameObject centerLight; 
    public GameObject _cycle; 
    public GameObject _player;
    
    #endregion


    private void Start()
    {
        
        _thisLight = centerLight.GetComponent<Light>();
        _thisLight.gameObject.SetActive(false); 
    }

    private void Update()
    {
        Upper();
        gameObject.transform.localScale = _newScale; 
    }


    //Upper Void
    #region
    void Upper()
    {
        if (_player.transform.position.y > _cycle.transform.position.y)
        {
            x += .01f; y += .01f; z += .01f ;
            _newScale = new Vector3(x, y, z); 
            _alttitude = _player.transform.position.y;
            _cycle.GetComponent<Rigidbody>().position = new Vector3(0, _alttitude, 0);
        }
        else
        {

            StartCoroutine(Waiting());
        }
    }
    #endregion

    //Coroutine Waiting
    #region
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(10);
        _thisLight.gameObject.SetActive(false);
    }
    #endregion

    //ChangeColors void 
    #region
    void ChangeColors()
    {

    }
    #endregion

    //OntriggerEnter
    #region
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Stage")
        {
            _newAlttitude = collider.transform.position.y;
            _cycle.transform.position = new Vector3(0, _newAlttitude, 0);

        }
    }
    #endregion




}
