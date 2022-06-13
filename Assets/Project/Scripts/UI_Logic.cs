using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UI_Logic : MonoBehaviour
{
    protected bool _isAction;
    //protected bool _isSelect;
    //protected Vector2 _v2Action;

    //Handle + Action
    public void HandleStart(InputAction.CallbackContext context)
    {
        if (context.started) //OnTriggerEnter
        {
            _isAction = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (context.canceled) //OnTriggerExit
        {
            _isAction = false;
        }
    }

    /*
    public void HandleSelect(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _isSelect = true;
        }
        else if (context.canceled)
        {
            _isSelect = false;
        }
    }

    public void HandleMoveCursor(InputAction.CallbackContext context)
    {
        _v2Action = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if (_isAction)
        {
            transform.position += 5.0f * new Vector3(_v2Action.x, 0.0f, _v2Action.y) * Time.deltaTime;
        }
    }
    */
}
