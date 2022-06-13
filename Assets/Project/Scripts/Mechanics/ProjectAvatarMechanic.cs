using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMechanics;
using ECM.Controllers;
using ECM.Components;

public class ProjectAvatarMechanic : AvatarMechanic
{
    public BaseFirstPersonController _scrBaseFirstPersonController;
    public RotationByMouseControl _scrRotationByMouseControl;
    public Transform _traPickableObject;
    public Transform _traCamera;
    //public MouseLook _scrMouseLook;

    protected GameObject _goPickableObject;
    protected Ray _ray = new Ray();
    protected RaycastHit _raycastHit;

    protected bool _isFirstPickableAction;

    #region HandleCoreMechanic

    public override void HandleCoreMechanic(CoreMechanicType type, bool value)
    {
        switch (type)
        {
            case CoreMechanicType.ACTION:
                ReleasePickableObject();
                break;
            case CoreMechanicType.CROUCH:
                _scrBaseFirstPersonController.crouch = value;
                break;
            case CoreMechanicType.JUMP:
                _scrBaseFirstPersonController.jump = value;
                break;
            case CoreMechanicType.LOCK_CURSOR:
                //_scrMouseLook.IsCursorLocked = value;
                break;
            case CoreMechanicType.RUN:
                _scrBaseFirstPersonController.run = value;
                break;
            case CoreMechanicType.SHOOT:

                break;
            case CoreMechanicType.UNLOCK_CURSOR:
                //_scrMouseLook.IsCursorLocked = value;
                break;
            case CoreMechanicType.START:
                _scrBaseFirstPersonController.pause = value;
                //_scrMouseLook.IsCursorLocked = !value;
                break;
        }
    }

    public override void HandleCoreMechanic(CoreMechanicType type, Vector2 value)
    {
        switch (type)
        {
            case CoreMechanicType.CAMERA:
                //_scrMouseLook.HandleCameraYawAndPitch(value);
                _scrRotationByMouseControl.deltaHorizontalAxis = value.x;
                _scrRotationByMouseControl.deltaVerticalAxis = value.y;
                break;
            case CoreMechanicType.MOVE:
                _scrBaseFirstPersonController.moveDirection = new Vector3(value.x, 0.0f, value.y);
                break;
        }
    }

    public override void HandleCoreMechanic(CoreMechanicType type, float value)
    {
        switch (type)
        {
            default:
                
                break;
        }
    }

    #endregion

    #region HandleIntersectionEventes

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 9) //Goal
        {
            _scrRefereeMechanic.AchievedGoalMechanic();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        //if (other.gameObject.tag == "Interactive Object")
        if (other.gameObject.layer == 13) //Pickable Object
        {
            if (_scrRefereeMechanic.GetCoreMechanicDefinition(CoreMechanicType.ACTION)._isValue)
            {
                PickPickableObject(other.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11) //Coin
        {
            other.gameObject.SetActive(false);
            ((ProjectRefereeMechanic)_scrRefereeMechanic).AddScore(1);
        }
    }

    #endregion

    #region SpecificInGameEvents

    protected void PickPickableObject(GameObject value)
    {
        _ray.origin = _traCamera.position;
        _ray.direction = _traCamera.forward;

        if (Physics.Raycast(_ray, out _raycastHit, 3.0f))
        {
            if (_raycastHit.collider.gameObject == value)
            {
                _goPickableObject = value;
                _goPickableObject.transform.parent = _traPickableObject;

                _goPickableObject.GetComponent<Rigidbody>().isKinematic = true;
                _goPickableObject.GetComponent<Rigidbody>().useGravity = false;
                _goPickableObject.transform.localPosition = Vector3.zero;
                _goPickableObject.transform.localRotation = Quaternion.identity;

                _isFirstPickableAction = true;
            }
        }
    }

    protected void ReleasePickableObject()
    {
        if (_goPickableObject != null && !_isFirstPickableAction)
        {
            _goPickableObject.GetComponent<Rigidbody>().isKinematic = false;
            _goPickableObject.GetComponent<Rigidbody>().useGravity = true;

            _goPickableObject.transform.parent = transform.root;
            _goPickableObject = null;
        }
        if (_isFirstPickableAction)
        {
            _isFirstPickableAction = false;
        }
    }

    #endregion
}
