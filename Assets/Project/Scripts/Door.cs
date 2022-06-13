using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorState
{
    IDLE_CLOSED,
    OPEN_DOOR,
    IDLE_OPENED,
    CLOSE_DOOR
}

public class Door : MonoBehaviour
{
    public GameObject _goLeftDoor;
    public GameObject _goRightDoor;
    public float _fltTimeToMoveDoor;
    public DoorState _defState = DoorState.IDLE_CLOSED;

    protected float _fltCronometerDoor = 0.0f;    

    protected Vector3 _v3LeftDoorClosedRotation = new Vector3(0.0f, -90.0f, 0.0f);
    protected Vector3 _v3LeftDoorOpenedRotation = new Vector3(0.0f, 0.0f, 0.0f);
    protected Vector3 _v3RightDoorClosedRotation = new Vector3(0.0f, 90.0f, 0.0f);
    protected Vector3 _v3RightDoorOpenedRotation = new Vector3(0.0f, 0.0f, 0.0f);

    public void OpenDoor()
    {
        _defState = DoorState.OPEN_DOOR;
    }

    public void CloseDoor()
    {
        _defState = DoorState.CLOSE_DOOR;
        _fltCronometerDoor = _fltTimeToMoveDoor - _fltCronometerDoor;
    }

    private void Update()
    {
        switch (_defState)
        {
            case DoorState.OPEN_DOOR:
                OpenDoorMotionGraphic();
                break;
            case DoorState.CLOSE_DOOR:
                CloseDoorMotionGraphic();
                break;
            case DoorState.IDLE_CLOSED:
                _goLeftDoor.transform.localRotation = Quaternion.Euler(_v3LeftDoorClosedRotation);
                _goRightDoor.transform.localRotation = Quaternion.Euler(_v3RightDoorClosedRotation);
                break;
            case DoorState.IDLE_OPENED:
                _goLeftDoor.transform.localRotation = Quaternion.Euler(_v3LeftDoorOpenedRotation);
                _goRightDoor.transform.localRotation = Quaternion.Euler(_v3RightDoorOpenedRotation);
                break;
        }
    }

    protected void OpenDoorMotionGraphic()
    {
        _fltCronometerDoor += Time.deltaTime;

        _goLeftDoor.transform.localRotation =
            Quaternion.Euler(
                Vector3.Lerp(
                    _v3LeftDoorClosedRotation,
                    _v3LeftDoorOpenedRotation,
                    _fltCronometerDoor / _fltTimeToMoveDoor
                )
            );
        _goRightDoor.transform.localRotation =
            Quaternion.Euler(
                Vector3.Lerp(
                    _v3RightDoorClosedRotation,
                    _v3RightDoorOpenedRotation,
                    _fltCronometerDoor / _fltTimeToMoveDoor
                )
            );

        if (_fltCronometerDoor >= _fltTimeToMoveDoor)
        {
            _defState = DoorState.IDLE_OPENED;
        }
    }

    protected void CloseDoorMotionGraphic()
    {
        _fltCronometerDoor += Time.deltaTime;

        _goLeftDoor.transform.localRotation =
            Quaternion.Euler(
                Vector3.Lerp(
                    _v3LeftDoorOpenedRotation,
                    _v3LeftDoorClosedRotation,
                    _fltCronometerDoor / _fltTimeToMoveDoor
                )
            );
        _goRightDoor.transform.localRotation =
            Quaternion.Euler(
                Vector3.Lerp(
                    _v3RightDoorOpenedRotation,
                    _v3RightDoorClosedRotation,
                    _fltCronometerDoor / _fltTimeToMoveDoor
                )
            );

        if (_fltCronometerDoor >= _fltTimeToMoveDoor)
        {
            _defState = DoorState.IDLE_CLOSED;
        }
    }
}
