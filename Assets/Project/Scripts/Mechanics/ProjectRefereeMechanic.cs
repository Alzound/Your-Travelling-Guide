using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMechanics;

public class ProjectRefereeMechanic : RefereeMechanic
{
    protected float _fltTimeRemaining;
    protected int _intScore;

    public float _fltGameTime = 60.0f;

    public NonDiegeticUI _scrNonDiegeticUI;

    private void Awake()
    {
        _fltTimeRemaining = _fltGameTime;
    }

    #region RefereeMechanics

    private void Update()
    {
        if (_gameState == GameState.IN_GAME)
        {
            _fltTimeRemaining -= Time.deltaTime;
            _scrNonDiegeticUI.SetRemainingTime(_fltTimeRemaining);

            /*
            if (_fltTimeRemaining <= 0.0f)
            {
                FailedGoalMechanic();
            }
            */
        }
    }

    #endregion

    #region HandleCoreMechanic

    public override void HandleCoreMechanic(CoreMechanicType type, bool value)
    {
        switch (type)
        {
            case CoreMechanicType.ACTION:
                if (_gameState == GameState.WIN_GAME || _gameState == GameState.FAIL_GAME)
                {
                    StartMechanic();
                }
                else
                {
                    _scrAvatarMechanic.HandleCoreMechanic(type, value);
                }
                break;
            case CoreMechanicType.CROUCH:
            case CoreMechanicType.JUMP:
            case CoreMechanicType.LOCK_CURSOR:
            case CoreMechanicType.RUN:
            case CoreMechanicType.SHOOT:
            case CoreMechanicType.UNLOCK_CURSOR:
                _scrAvatarMechanic.HandleCoreMechanic(type, value);
                break;
            case CoreMechanicType.START:
                StartMechanic();
                if (_gameState == GameState.IN_GAME || _gameState == GameState.PAUSE_GAME)
                {
                    _scrNonDiegeticUI.TogglePauseScreen();
                }
                break;
            case CoreMechanicType.SELECT:
                SelectMechanic();
                break;
        }
    }

    public override void HandleCoreMechanic(CoreMechanicType type, Vector2 value)
    {
        switch (type)
        {
            case CoreMechanicType.CAMERA:
            case CoreMechanicType.MOVE:
                _scrAvatarMechanic.HandleCoreMechanic(type, value);
                _scrNonDiegeticUI.UpdateUITransform();
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

    #region GoalStateMechanics

    public override void StartMechanic()
    {
        base.StartMechanic();

        if (_gameState != GameState.IN_GAME)
        {
            _scrAvatarMechanic.HandleCoreMechanic(CoreMechanicType.START, true);
        }
        else
        {
            _scrAvatarMechanic.HandleCoreMechanic(CoreMechanicType.START, false);
        }
    }

    public void AddScore(int score)
    {
        if (_gameState == GameState.IN_GAME)
        {
            _intScore += score;
            _scrNonDiegeticUI.SetScore(_intScore);
        }
    }

    public override void FailedGoalMechanic()
    {
        base.FailedGoalMechanic();
        _scrAvatarMechanic.HandleCoreMechanic(CoreMechanicType.START, true);
        _scrNonDiegeticUI.ActivateFailScreen();
    }

    public override void AchievedGoalMechanic()
    {
        base.AchievedGoalMechanic();
        _scrAvatarMechanic.HandleCoreMechanic(CoreMechanicType.START, true);
        _scrNonDiegeticUI.ActivateAchieveScreen();
    }

    #endregion
}
