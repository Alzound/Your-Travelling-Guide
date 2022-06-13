using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InterruptorState
{
    IDLE_ON,
    IDLE_OFF,
    TURN_ON,
    TURN_OFF
}

public class Interruptor : MonoBehaviour
{
    public Door _scrDoor01;
    public Door _scrDoor02;
    public GameObject _goInterruptor;
    public float _fltTimeInterruptor;

    protected Vector3 _v3InterruptorOff = new Vector3(-30.0f, 0.0f, 0.0f);
    protected Vector3 _v3InterruptorOn = new Vector3(30.0f, 0.0f, 0.0f);

    protected float _fltCronometerInterruptor;

    protected InterruptorState _defState = InterruptorState.IDLE_OFF;

    public void Turn()
    {
        if (_defState == InterruptorState.IDLE_ON)
            _defState = InterruptorState.TURN_OFF;
        else if (_defState == InterruptorState.IDLE_OFF)
            _defState = InterruptorState.TURN_ON;
    }

    private void Update()
    {
        switch (_defState)
        {
            case InterruptorState.TURN_ON:
                TurnOnMotionGraphic();
                break;
            case InterruptorState.TURN_OFF:
                TurnOffMotionGraphic();
                break;
            case InterruptorState.IDLE_OFF:
                _goInterruptor.transform.localRotation = Quaternion.Euler(_v3InterruptorOff);
                break;
            case InterruptorState.IDLE_ON:
                _goInterruptor.transform.localRotation = Quaternion.Euler(_v3InterruptorOn);
                break;
        }
    }

    protected void TurnOnMotionGraphic()
    {
        _fltCronometerInterruptor += Time.deltaTime;

        _goInterruptor.transform.localRotation =
            Quaternion.Euler(
                Vector3.Lerp(
                    _v3InterruptorOff,
                    _v3InterruptorOn,
                    _fltCronometerInterruptor / _fltTimeInterruptor
                )
            );

        if (_fltCronometerInterruptor >= _fltTimeInterruptor)
        {
            _fltCronometerInterruptor = 0.0f;
            _defState = InterruptorState.IDLE_ON;
            _scrDoor01.CloseDoor();
            _scrDoor02.OpenDoor();
        }
    }

    protected void TurnOffMotionGraphic()
    {
        _fltCronometerInterruptor += Time.deltaTime;

        _goInterruptor.transform.localRotation =
            Quaternion.Euler(
                Vector3.Lerp(
                    _v3InterruptorOn,
                    _v3InterruptorOff,
                    _fltCronometerInterruptor / _fltTimeInterruptor
                )
            );

        if (_fltCronometerInterruptor >= _fltTimeInterruptor)
        {
            _fltCronometerInterruptor = 0.0f;
            _defState = InterruptorState.IDLE_OFF;
            _scrDoor01.OpenDoor();
            _scrDoor02.CloseDoor();
        }
    }
}
