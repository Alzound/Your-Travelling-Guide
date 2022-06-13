using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameMechanics
{
    public enum CoreMechanicType
    {
        JUMP,
        CROUCH,
        RUN,
        ACTION,
        SHOOT,
        SELECT,
        START,
        UNLOCK_CURSOR,
        LOCK_CURSOR,
        MOVE,
        CAMERA,
        TOUCH,
        TAP
    }

    public class CoreMechanicDefinition
    {
        public CoreMechanicType _defType;
        public bool _isValue;
        public float _fltValue;
        public Vector2 _v2Value;
    }

    public class CoreMechanics : MonoBehaviour
    {
        public RefereeMechanic _scrRefereeMechanic;

        #region CoreMechanics

        protected bool _actJump;
        protected bool _actCrouch;
        protected bool _actRun;
        protected bool _actAction;
        protected bool _actShoot;
        protected bool _actSelect;
        protected bool _actStart;
        protected bool _actUnlockCursor;
        protected bool _actLockCursor;
        protected bool _actTap;

        protected Vector2 _actMove;
        protected Vector2 _actCamera;
        protected Vector2 _actTouch;

        #endregion

        private void Awake()
        {
            if (_scrRefereeMechanic == null)
            {
                _scrRefereeMechanic = GetComponent<RefereeMechanic>();
            }
        }

        #region HandleActions

        public virtual void HandleRun(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _actRun = true;
            }
            if (context.canceled)
            {
                _actRun = false;
            }
            _scrRefereeMechanic.HandleCoreMechanic(CoreMechanicType.RUN, _actRun);
        }

        public virtual void HandleCrouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _actCrouch = true;
            }
            if (context.canceled)
            {
                _actCrouch = false;
            }
            _scrRefereeMechanic.HandleCoreMechanic(CoreMechanicType.CROUCH, _actCrouch);
        }

        public virtual void HandleJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _actJump = true;
            }
            if (context.canceled)
            {
                _actJump = false;
            }
            _scrRefereeMechanic.HandleCoreMechanic(CoreMechanicType.JUMP, _actJump);
        }

        public virtual void HandleMove(InputAction.CallbackContext context)
        {
            _actMove = context.ReadValue<Vector2>();
            _scrRefereeMechanic.HandleCoreMechanic(CoreMechanicType.MOVE, _actMove);
        }

        public virtual void HandleStart(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _actStart = true;
            }
            if (context.canceled)
            {
                _actStart = false;
            }
            _scrRefereeMechanic.HandleCoreMechanic(CoreMechanicType.START, _actStart);
        }

        public virtual void HandleSelect(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _actSelect = true;
            }
            if (context.canceled)
            {
                _actSelect = false;
            }
            _scrRefereeMechanic.HandleCoreMechanic(CoreMechanicType.SELECT, _actSelect);
        }

        public virtual void HandleAction(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _actAction = true;
            }
            if (context.canceled)
            {
                _actAction = false;
            }
            _scrRefereeMechanic.HandleCoreMechanic(CoreMechanicType.ACTION, _actAction);
        }

        public virtual void HandleShoot(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _actShoot = true;
            }
            if (context.canceled)
            {
                _actShoot = false;
            }
            _scrRefereeMechanic.HandleCoreMechanic(CoreMechanicType.SHOOT, _actShoot);
        }

        public virtual void HandleLockCursor(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _actLockCursor = true;
            }
            _scrRefereeMechanic.HandleCoreMechanic(CoreMechanicType.LOCK_CURSOR, _actLockCursor);
        }

        public virtual void HandleUnlockCursor(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _actUnlockCursor = false;
            }
            _scrRefereeMechanic.HandleCoreMechanic(CoreMechanicType.UNLOCK_CURSOR, _actUnlockCursor);
        }

        public virtual void HandleCamera(InputAction.CallbackContext context)
        {
            _actCamera.x = context.ReadValue<Vector2>().x;
            _actCamera.y = context.ReadValue<Vector2>().y;
            _scrRefereeMechanic.HandleCoreMechanic(CoreMechanicType.CAMERA, _actCamera);
        }

        public virtual void HandleTouch(InputAction.CallbackContext context)
        {
            _actTouch.x = context.ReadValue<Vector2>().x;
            _actTouch.y = context.ReadValue<Vector2>().y;
        }

        public virtual void HandleTap(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _actTap = true;
                _actMove = Vector2.up;
            }
            if (context.canceled)
            {
                _actTap = false;
                _actAction = false;
                _actMove = Vector2.zero;
                _scrRefereeMechanic.HandleCoreMechanic(CoreMechanicType.MOVE, _actMove);
            }

            if (_actTap)
            {
                if (_actTouch.x < Screen.width * 0.5f)
                {
                    _actAction = true;
                    _actMove = Vector2.zero;
                }
                else
                {
                    _actAction = false;
                    _scrRefereeMechanic.HandleCoreMechanic(CoreMechanicType.MOVE, _actMove);
                }
            }
        }

        #endregion

        #region Getters

        public CoreMechanicDefinition GetCoreMechanicDefinition(CoreMechanicType value)
        {
            CoreMechanicDefinition _defCoreMechanic = new CoreMechanicDefinition();
            _defCoreMechanic._defType = value;
            
            switch (value)
            {
                case CoreMechanicType.ACTION:
                    _defCoreMechanic._isValue = _actAction;
                    break;
                case CoreMechanicType.CAMERA:
                    _defCoreMechanic._v2Value = _actCamera;
                    break;
                case CoreMechanicType.CROUCH:
                    _defCoreMechanic._isValue = _actCrouch;
                    break;
                case CoreMechanicType.JUMP:
                    _defCoreMechanic._isValue = _actJump;
                    break;
                case CoreMechanicType.LOCK_CURSOR:
                    _defCoreMechanic._isValue = _actLockCursor;
                    break;
                case CoreMechanicType.MOVE:
                    _defCoreMechanic._v2Value = _actMove;
                    break;
                case CoreMechanicType.RUN:
                    _defCoreMechanic._isValue = _actRun;
                    break;
                case CoreMechanicType.SELECT:
                    _defCoreMechanic._isValue = _actSelect;
                    break;
                case CoreMechanicType.SHOOT:
                    _defCoreMechanic._isValue = _actShoot;
                    break;
                case CoreMechanicType.START:
                    _defCoreMechanic._isValue = _actStart;
                    break;
                case CoreMechanicType.UNLOCK_CURSOR:
                    _defCoreMechanic._isValue = _actUnlockCursor;
                    break;
            }


            return _defCoreMechanic;
        }

        #endregion
    }
}